# SOAP → Tauri Command Mapping

## Overview

Every `pService.GetData()`, `pService.UpdateData()`, and `pService.SelectData()` call must become a Tauri command in v2. This document maps legacy calls to proposed command names and signatures.

## Format

Each entry:

```
Legacy:        pService.GetData("Drug", sqlString)
Entity:        Drug
SQL Pattern:   SELECT ... WHERE [condition]
Call Site:     Form.vb:lineNo
Proposed Cmd:  get_drug_data
Signature:     get_drug_data(goodCode: String) -> Result<DrugData, AppError>
Notes:         [special handling]
```

---

## Authentication Commands

### Login

```
Legacy:        pService.GetData("Drug", "SELECT ... FROM EmplInfo ... WHERE userName=? AND userPWD=?")
Call Site:     frmLogIn.vb:184
Proposed Cmd:  login
Signature:     login(userName: String, userPWD: String) -> Result<LoginResponse, AuthError>
Returns:       { emplCode, emplName, emplID, privCode, emplPosiName }
Notes:         Must use bcrypt hash comparison on server; plaintext password from client
               Over HTTPS only. Create pLogSession on server, return in response.
```

### Quick Auth (Mid-Session)

```
Legacy:        pService.GetData("Drug", "SELECT emplCode, emplName, privCode FROM EmplInfo WHERE ... userName=? AND userPWD=?")
Call Site:     frmPass.vb:23
Proposed Cmd:  quick_auth
Signature:     quick_auth(userName: String, userPWD: String) -> Result<QuickAuthResponse, AuthError>
Returns:       { emplCode, emplName, privCode }
Notes:         Simpler than login; no position lookup, no logging. For access control within session.
```

### Change Password

```
Legacy:        pService.GetData("Drug", "Select userName, userPWD From EmplInfo Where emplCode = ?")
               pService.GetData("Drug", "Select emplCode From EmplInfo Where userName = ? And emplCode <> ?")
               pService.UpdateData("Drug", ["Update EmplInfo set userName = ?, userPWD = ? Where emplCode = ?"])
Call Site:     frmChangePassword.vb:15, 36, 45
Proposed Cmd:  change_password
Signature:     change_password(currentPassword: String, newUsername: String, newPassword: String) -> Result<String, AuthError>
Notes:         Server validates currentPassword matches session user before allowing change
               Must enforce password strength on server
```

### Enroll Fingerprint

```
Legacy:        pService.GetData("Drug", "SELECT emplCode, emplName FROM EmplInfo WHERE emplCode = ?")
               pService.UpdateData("Drug", ["UPDATE EmplInfo SET emplFinger = ? WHERE emplCode = ?"])
Call Site:     frmFingerPrintEnroll.vb
Proposed Cmd:  enroll_fingerprint
Signature:     enroll_fingerprint(fingerTemplate: Vec<u8>) -> Result<String, HardwareError>
Notes:         Client captures fingerprint, sends template binary to server
               Server stores in EmplInfo.emplFinger (BLOB)
```

---

## Product / Drug Commands

### Get Product by Barcode

```
Legacy:        pService.GetData("Drug", "Select top 1 goodCode, unitCode from GoodBarcode where barCode = ?")
Call Site:     frmSale.vb:231
Proposed Cmd:  get_drug_by_barcode
Signature:     get_drug_by_barcode(barCode: String) -> Result<DrugBarcode, NotFoundError>
Returns:       { goodCode, unitCode }
Notes:         Barcode lookup for POS scanning. If not found, alert operator.
```

### Get Product Details & Pricing

```
Legacy:        pService.SelectData("Drug", "SELECT GB.*, GI.goodName, GI.unitCostXX as unitCost, ... FROM GoodBarcode GB INNER JOIN GoodInfo GI ... WHERE barCode = ? AND GI.goodStat = '1'")
Call Site:     frmSale.vb:254
Proposed Cmd:  get_drug_pricing
Signature:     get_drug_pricing(barCode: String, branchCode: String) -> Result<DrugPricingData, Error>
Returns:       { goodCode, goodName, unitCode, goodAmou, unitDesc, unitFactor, membDisc, emplDisc, wholeDisc, unitCost, stockOnhand, miniStock, prices: [price1, price2, ...], stickerPrice, fixPrice, drugCode, cateCode, typeCode, groupCode }
Notes:         Consolidates multiple SELECT columns into single response
               Server applies branchCode-specific stock/cost fields
               Returns all price tiers (client selects which to display based on config)
```

### Stock on Hand

```
Legacy:        pService.GetData("Drug", "Select stockOnhandXX from GoodInfo where goodCode = ?")
Call Site:     DrugMod.vb:741
Proposed Cmd:  get_stock_onhand
Signature:     get_stock_onhand(goodCode: String) -> Result<StockData, Error>
Returns:       { stockOnhand, miniStock, stockCount, lastSale, unitCost, shelfNo }
Notes:         Used to check availability before sale. Fetches current branch stock.
```

### Good Branch Info

```
Legacy:        pService.SelectData("Drug", "Select * from GoodBranchInfo where goodCode = ? and branchCode = ?")
Call Site:     DrugMod.vb:1250
Proposed Cmd:  get_good_branch_info
Signature:     get_good_branch_info(goodCode: String, branchCode: String) -> Result<GoodBranchInfo, Error>
Returns:       { stockOnhand, stockCount, miniStock, shelfNo, lastSale, unitCost }
Notes:         Explicit per-branch product info. May be redundant with get_drug_pricing.
               Consider consolidating.
```

---

## Customer Commands

### Customer Search

```
Legacy:        pService.GetData("Drug", "SELECT custCode, custName, custTypeCode FROM CustInfo WHERE custCode = ?")
Call Site:     frmSale.vb (presumed, specific line not visible)
Proposed Cmd:  get_customer
Signature:     get_customer(custCode: String) -> Result<CustomerData, NotFoundError>
Returns:       { custCode, custName, custTypeCode, custPoint, custBirth, custJoinDate }
Notes:         Customer lookup for receipt and loyalty calculation
```

### Member Info / Loyalty Points

```
Legacy:        pService.GetData("Drug", "SELECT ... FROM CustInfo WHERE custCode = ?") [for points]
Call Site:     frmMemberInfo.vb:1 (inferred)
Proposed Cmd:  get_customer_points
Signature:     get_customer_points(custCode: String) -> Result<PointsData, Error>
Returns:       { custCode, custName, custPoint, custTypeCode, thisMonthPoints, pointHistory: [{ date, earned, redeemed }] }
Notes:         Summary of loyalty account. May require aggregation from HistSalePro.
```

### Update Customer Allergy

```
Legacy:        [Not fully visible, but DrugAllergic table must be writable]
Call Site:     frmMemberInfo.vb (presumed)
Proposed Cmd:  set_customer_allergy
Signature:     set_customer_allergy(custCode: String, drugCode: String, remove: bool) -> Result<String, Error>
Notes:         Add/remove drug from customer's allergy list
               Used before frmSale checks allergies
```

---

## Sale / Transaction Commands

### Check Allergy

```
Legacy:        pService.GetData("Drug", "SELECT DG.drugDesc FROM DrugAllergic DA INNER JOIN DrugGroup DG ... WHERE DA.custCode = ? AND DA.drugCode = ?")
Call Site:     frmSale.vb:365
Proposed Cmd:  check_allergy
Signature:     check_allergy(custCode: String, drugCode: String) -> Result<AllergyCheckResponse, Error>
Returns:       { hasAllergy: bool, drugDesc: String }
Notes:         Safety check before adding product to sale. If hasAllergy=true, user prompted.
```

### Create Sale

```
Legacy:        pService.UpdateData("Drug", [INSERT INTO HistSale, INSERT INTO SaleList x N, UPDATE GoodInfo stock, ...])
Call Site:     frmSalePaid.vb (presumed, full logic not visible)
Proposed Cmd:  create_sale
Signature:     create_sale(sale: SaleInput) -> Result<SaleResponse, Error>
Input:         { custCode, emplCode, cashCode, totalPrice, totalDisc, totalCost, totalPay, totalCash, totalCredit, payType, creditCode, creditNumb, items: [{ goodCode, goodAmou, unitCode, unitPrice, unitCost, subDisc }], payments: [{ cardCode, payAmou }] }
Returns:       { saleNumb, saleDate, saleTime }
Notes:         Atomic transaction: all items or nothing
               Server calculates saleNumb, applies taxes, updates stock, logs in FrontCard
               Returns sale number for receipt printing
```

### Loyalty Points Earn/Redeem

```
Legacy:        [HistSalePro insert during create_sale]
Call Site:     frmSalePaid.vb (part of create_sale)
Proposed Cmd:  [Included in create_sale; separate if needed]
Signature:     If separate: post_sale_points(saleNumb: String, custCode: String, pointsEarned: i32, pointsRedeemed: i32) -> Result<PointsData, Error>
Notes:         Called after sale created. Updates HistSalePro and CustInfo.custPoint.
               May be atomic with create_sale or separate transaction.
```

### Get Active Promotions

```
Legacy:        pService.SelectData("Drug", "SELECT * FROM SalePro WHERE proStat <> '0' AND ... startDate <= ? AND endDate >= ? ORDER BY buyPrice DESC")
Call Site:     frmSale.vb:125
Proposed Cmd:  get_active_promotions
Signature:     get_active_promotions(branchCode: String, branchPrice: String, saleDate: Date) -> Result<Vec<Promotion>, Error>
Returns:       [{ proNo, proDesc, buyPrice, custTypeCode, extraPoint, plusPoint, freeMember, startDate, endDate }]
Notes:         Loaded at form load; displayed in UI for operator reference
               Promotions matched against customer type during sale finalization
```

### Calculate Sale Discount

```
Legacy:        [Logic spread across frmSale.vb line 400+; not cleanly extracted]
Call Site:     frmSale.vb:400+ (complex calculation)
Proposed Cmd:  calculate_discount
Signature:     calculate_discount(cartItems: Vec<CartItem>, custTypeCode: String, saleTotal: f64, promotions: Vec<Promotion>) -> Result<DiscountBreakdown, Error>
Returns:       { totalDiscount, itemDiscounts: [{ goodCode, discount }], appliedPromotions: [proNo], finalTotal }
Notes:         This is a new helper command to extract the complex discount logic
               Helps with testability and logic clarity
```

---

## Stock & Inventory Commands

### Reduce Stock (On Sale)

```
Legacy:        pService.UpdateData("Drug", ["UPDATE GoodInfo SET stockOnhandXX = stockOnhandXX - ?, lastSaleXX = ? WHERE goodCode = ?"])
Call Site:     frmUploadServer.vb:207 (for offline sync); frmSale.vb (inline, if any)
Proposed Cmd:  [Included in create_sale; separate if needed]
Signature:     If separate: reduce_stock(goodCode: String, branchCode: String, quantity: i32) -> Result<String, Error>
Notes:         Usually atomic with sale creation. Separate command if needed for inventory adjustments.
```

### Adjust Stock (Manual)

```
Legacy:        [frmGoodAdjust.vb - not fully visible]
Call Site:     frmGoodAdjust.vb (presumed)
Proposed Cmd:  adjust_stock
Signature:     adjust_stock(goodCode: String, branchCode: String, adjustment: i32, reason: String) -> Result<String, Error>
Notes:         Manual stock correction. Creates audit record (FrontCard with workType='ADJ').
```

### Stock Count / Inventory

```
Legacy:        [frmGoodCheck.vb - not fully visible]
Call Site:     frmGoodCheck.vb
Proposed Cmd:  post_stock_count
Signature:     post_stock_count(branchCode: String, countDate: Date, counts: Vec<{ goodCode, countedQty }>) -> Result<String, Error>
Notes:         Physical inventory count entry. Updates stockCount column and reconciles vs stockOnhand.
```

---

## Accounting / Close Commands

### Get Close Summary

```
Legacy:        pService.SelectData("Drug", "SELECT CD.cardOrder, PL.cardCode, CD.cardName, CD.cardColor, SUM(PL.payAmou) as payAmou FROM SalePaidList PL INNER JOIN CardInfo CD ... WHERE HS.saleStat <> '0' AND HS.closeNumb = '0' AND HS.saleDate = ? AND HS.branchCode = ? GROUP BY ...")
Call Site:     frmAccoClose.vb:89
Proposed Cmd:  get_close_summary
Signature:     get_close_summary(branchCode: String, closeDate: Date) -> Result<CloseSummary, Error>
Returns:       { closeDateString, payments: [{ cardCode, cardName, cardColor, payAmou }], totalSales, totalCash, totalCredit, billCount }
Notes:         Prepares close summary for operator review before final commit
```

### Post Accounting Close

```
Legacy:        pService.UpdateData("Drug", [UPDATE HistSale SET closeNumb = ?, ...])
Call Site:     frmAccoClose.vb
Proposed Cmd:  post_accounting_close
Signature:     post_accounting_close(branchCode: String, closeDate: Date) -> Result<CloseResponse, Error>
Returns:       { closeNumb, closedSaleCount, closedRevenue, timestamp }
Notes:         Atomic: mark all sales for date as closed, generate GL entries, lock for modification
               No undo once committed.
```

---

## Offline Sync Commands

### Get Sync Status

```
Legacy:        pService.GetData("Drug", "SELECT COUNT(*) FROM HistSale WHERE flag = '1'")
Call Site:     frmUploadServer.vb:24
Proposed Cmd:  get_sync_status
Signature:     get_sync_status() -> Result<SyncStatus, Error>
Returns:       { pendingSalesCount, pendingTimestampCount, lastSyncTime }
Notes:         Called before upload to check if there's data to sync
```

### Upload Offline Sales

```
Legacy:        pService.UpdateData("Drug", [multiple INSERT/UPDATE batches for each offline sale])
Call Site:     frmUploadServer.vb:222 (complex loop)
Proposed Cmd:  upload_offline_sales
Signature:     upload_offline_sales(sales: Vec<OfflineSale>) -> Result<UploadResponse, SyncError>
Input:         [{ saleNumb, saleDate, saleTime, custCode, emplCode, cashCode, totalPrice, totalDisc, items, payments }]
Returns:       { uploadedSaleCount, syncedTimestamp, nextSaleNumb }
Notes:         Atomically uploads all queued offline sales and updates server stock
               May need chunking if many sales queued (batch size TBD)
```

### Confirm Offline Sync

```
Legacy:        UpdateData(["UPDATE HistSale SET flag = '2' WHERE saleNumb = ?"], "data.mdb")
Call Site:     frmUploadServer.vb:225
Proposed Cmd:  [Part of upload_offline_sales response callback]
Signature:     mark_sales_synced(saleNums: Vec<String>) -> Result<String, Error>
Notes:         After server confirms receipt, mark local flag = '2' to prevent re-upload
```

---

## Timecard Commands

### Clock In

```
Legacy:        pService.UpdateData("Drug", [INSERT INTO ETimeStamp])
Call Site:     frmTimeStamp.vb (presumed)
Proposed Cmd:  clock_in
Signature:     clock_in() -> Result<TimeStampResponse, Error>
Returns:       { emplCode, inTime, dateStamp }
Notes:         Records employee check-in. Stored in ETimeStamp (for offline) or server.
```

### Clock Out

```
Legacy:        pService.UpdateData("Drug", [UPDATE ETimeStamp SET outTime = ?])
Call Site:     frmTimeStamp.vb
Proposed Cmd:  clock_out
Signature:     clock_out() -> Result<TimeStampResponse, Error>
Returns:       { emplCode, inTime, outTime, dateStamp }
Notes:         Records employee check-out.
```

### Upload Timeclock

```
Legacy:        pService.UpdateData("Drug", [INSERT INTO ETimeStamp ... WHERE flag = '1'])
Call Site:     frmUploadServer.vb:248, 270
Proposed Cmd:  upload_timeclock
Signature:     upload_timeclock(timestamps: Vec<TimeStamp>) -> Result<String, Error>
Notes:         Syncs offline time records to server
```

---

## Reporting / Data Query Commands

### Stock Onhand Report

```
Legacy:        pService.SelectData("Drug", "SELECT goodName, unitDesc, ... stockOnhand ... FROM GoodInfo JOIN UnitInfo ...")
Call Site:     Various report forms (frmRpStockCard.vb, etc.)
Proposed Cmd:  get_stock_report
Signature:     get_stock_report(branchCode: String, reportDate: Date) -> Result<Vec<StockReportRow>, Error>
Returns:       [{ goodName, unitDesc, typeDesc, stockOnhand, totalCost, barCode, unitCost, unitPrice, GP, shelfNo }]
Notes:         Powers dtStockOnhand report dataset
```

### Sales Summary Report

```
Legacy:        pService.SelectData("Drug", "SELECT ... FROM HistSale GROUP BY ...[date, customer type, etc.]")
Call Site:     frmRpEmplSale.vb, frmRpPointUse.vb, etc.
Proposed Cmd:  get_sales_report
Signature:     get_sales_report(branchCode: String, startDate: Date, endDate: Date, groupBy: ReportGroupBy) -> Result<Vec<SalesReportRow>, Error>
Returns:       [{ period, groupKey, totalCost, totalSale, totalBill, avgBill, perGP }]
Notes:         Flexible grouping (by date, customer type, employee, product group)
               Supports multiple dataset views (dtHistSaleSum, dtHistSaleType, etc.)
```

---

## Branch Management Commands

### Get Branch Info

```
Legacy:        pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = ?")
Call Site:     frmUploadServer.vb:73
Proposed Cmd:  get_branch_info
Signature:     get_branch_info(branchCode: String) -> Result<BranchInfo, Error>
Returns:       { branchCode, branchName, saleNumb, ... }
Notes:         Fetches current sale number counter for document numbering
               Used during offline upload to generate next sale number
```

### Increment Sale Number

```
Legacy:        pService.UpdateData("Drug", ["UPDATE BranchInfo SET saleNumb = saleNumb + 1 WHERE branchCode = ?"])
Call Site:     frmUploadServer.vb:219
Proposed Cmd:  [Atomic with create_sale or upload_offline_sales]
Signature:     If separate: increment_sale_number(branchCode: String) -> Result<i32, Error>
Notes:         Usually incremented server-side within create_sale transaction
```

---

## Summary Statistics

| Category       | Commands | Notes                                                                         |
| -------------- | -------- | ----------------------------------------------------------------------------- |
| Authentication | 4        | login, quick_auth, change_password, enroll_fingerprint                        |
| Product/Drug   | 4        | get_drug_by_barcode, get_drug_pricing, get_stock_onhand, get_good_branch_info |
| Customer       | 3        | get_customer, get_customer_points, set_customer_allergy                       |
| Sales          | 4        | check_allergy, create_sale, get_active_promotions, calculate_discount         |
| Inventory      | 3        | reduce_stock (partial), adjust_stock, post_stock_count                        |
| Accounting     | 2        | get_close_summary, post_accounting_close                                      |
| Offline Sync   | 3        | get_sync_status, upload_offline_sales, mark_sales_synced                      |
| Timeclock      | 3        | clock_in, clock_out, upload_timeclock                                         |
| Reporting      | 2        | get_stock_report, get_sales_report                                            |
| Administration | 2        | get_branch_info, increment_sale_number                                        |
| **TOTAL**      | **~30**  | Estimated core command set for v2                                             |

⚠️ **Additional Commands TBD:**

- Return/refund processing (frmSaleReturn.vb)
- Buy exchange voucher issuance/redemption
- Promotion management (admin)
- Employee management (admin)
- System settings (admin)
- Export/import functions
