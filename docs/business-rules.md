# Business Rules

## Pricing Tier System

### Tier Selection (frmSale.vb)

**Stored Column:** `pBranchPrice` global variable

**How it works:**
1. `pBranchPrice` is set during startup (from BranchInfo config)
2. `pBranchPrice` becomes the tier suffix: "1", "2", "3", "4", "5", or "6"
3. When loading product pricing: `mRetailPriceField = "price" & pBranchPrice`
4. Query pulls: `SELECT ... GoodBarcode.price1, GB.price2, GB.price3, etc.`

**Example:**
```vb
If pBranchPrice = "3" Then
  mRetailPriceField = "price3"  ' Use price3 column for all products in this branch
End If
```

### Price Selection by Package Size

GoodBarcode contains multiple rows per product (different pack sizes):
```sql
goodCode="ABC123", goodAmou=1, unitPrice=100 (single tablet)
goodCode="ABC123", goodAmou=10, unitPrice=950 (box of 10)
goodCode="ABC123", goodAmou=100, unitPrice=9000 (case of 100)
```

Query returns all options sorted by goodAmou DESC. UI (dtgPrice) displays all; user selects one.

### Price Tiers & Member Pricing (frmSale.vb line 303-337)

⚠️ **Complex Price Tier Mapping** - if `pAllowOnlyMembPrice = "1"`:

When pBranchPrice = "price1", derive member price as:
- If fixPrice = "1": use price1 as-is
- If fixPrice = "0": calculate: `price1 / goodAmou * (1 + pPerPrice1ToPrice0%) rounded up`
- Cap at stickerPrice if defined

When pBranchPrice = "price2": use price1 for member (downgrade one tier)
When pBranchPrice = "price3": use price2 for member
When pBranchPrice = "price4": use price3 for member
When pBranchPrice = "price5": use price3 for member (skip tier 4)
When pBranchPrice = "price6": use price5 for member

**Purpose:** Show both "general" and "member" prices in UI to same customer based on membership status.

---

## Promotion Engine (frmSale.vb lines 118-151)

### Load Active Promotions

At form load, query all promotions applicable to today:

```sql
SELECT * FROM SalePro 
WHERE proStat <> '0' 
  AND ((branchCode = '[current]' AND branchPrice = '0') 
       OR (branchCode = '0' AND branchPrice = '0') 
       OR (branchCode = '0' AND branchPrice = '[tier]'))
  AND startDate <= '[today]' 
  AND endDate >= '[today]'
ORDER BY buyPrice DESC
```

**Result:** Loaded into dtgProTemp (temporary grid)

**Columns Captured:**
- proNo: Promotion ID
- proDesc: Description
- buyPrice: Minimum purchase to qualify
- extraPoint: Bonus points earned
- plusPoint: Points multiplier
- freeMember: "1" = free membership promo
- custTypeCode: Applies to specific customer type (null = all)
- startDate, endDate: Validity period

### Promotion Matching Rules

During sale:
1. Check if sale meets promotion buyPrice threshold
2. Check if customer type matches custTypeCode (if not null)
3. If matched: apply promotion's extraPoint and plusPoint
4. If freeMember="1": flag special handling (display on receipt)

⚠️ **Stacking:** Code loads multiple promotions but conflict resolution is unclear. Presumed: last-matching-wins or all-apply.

⚠️ **Time Format:** Dates compared using MDYStr format in SQL; risk if locale differs.

---

## Loyalty Points

### Earn Rules (frmSale.vb, HistSalePro table)

**Basic Earn:**
```
thisPoint = totalPrice / pBahtPerPoint
```

Where `pBahtPerPoint` = conversion rate (e.g., 1 point per 20 baht = pBahtPerPoint=20)

**Wholesale Earn:**
```
thisPoint = totalPrice / pWholeBahtPerPoint
```

**Bonus Earn (Promotions):**
```
thisPoint += promotion.extraPoint + (totalPrice / 100) * promotion.plusPoint
```

**Birthday Bonus:**
```
thisPoint *= pBirthPointPlus
```

Applied if sale date matches customer's custBirth month/day.

### Redeem Rules

**Conversion:** 1 point redeems to X baht discount
```
pointDisc = usePoint * (pointValue)  ' pointValue not explicitly defined; presumed 1:1 or better
```

**Minimum Threshold:** Not documented; presumed configurable via global or table.

**Expiry:** Not enforced in code; CustInfo.custPoint appears to be cumulative balance, not time-bounded.

### Point Storage

- **HistSalePro.thisPoint** = points earned in this transaction
- **HistSalePro.usePoint** = points redeemed in this transaction
- **HistSalePro.remainPoint** = balance after transaction
- **CustInfo.custPoint** = overall balance (TBD: updated after HistSalePro insert or separate batch?)

---

## Allergy Checking

### Trigger (frmSale.vb line 362-377)

```vb
If txtCustCode.Text <> "0" AndAlso txtCustCode.Text <> "" Then
  getValue = pService.GetData("Drug", 
    "SELECT DG.drugDesc 
     FROM DrugAllergic DA 
     INNER JOIN DrugGroup DG ON DA.drugCode = DG.drugCode 
     WHERE DA.custCode = '[cust]' AND DA.drugCode = '[drug]'")
  If getValue(0) = "1" Then
    pMessageBox.ShowDialog()
    If DialogResult = No Then
      Exit Sub  ' Don't add product
    End If
  End If
End If
```

### Condition

- Only checks if customer is specified (not cash sale)
- Queries DrugAllergic table linking customer → drug code
- Drug code comes from GoodInfo.drugCode

### Response

If allergy found:
- Show warning: "ผลิตภัณฑ์นี้มีส่วนประกอบที่ท่านแพ้: [drug description]"
- Offer Yes/No dialog
- If No: cancel adding product to sale
- If Yes: allow product (override)

⚠️ **No Audit:** Override not logged; no way to track who bypassed allergy check.

---

## Discount System

### Line-Item Discount (subDisc)

Each SaleList item can have `subDisc` (line discount amount in baht):

```
totalLinePrice = (goodAmou * unitPrice) - subDisc
```

Applied per product; cumulative across all items = `totalDisc`.

### Customer Type Discount

From GroupInfo table:
- membDisc: Applied to member customers
- emplDisc: Applied to employee customers
- wholeDisc: Applied to wholesale

Applied to group average or entire sale (exact mechanism unclear; possibly per-item).

### Promotion Discount

If promotion matched: may apply buyPrice-based discount or direct amount (exact formula unclear).

### Manual Discount

If `pAllowDisc = "1"`:
- Operator can manually adjust discount amount
- Applied to sale total or specific lines (unclear)

### Discount Application Order

⚠️ **Ambiguous:** Code references mGoodDisc, mCompDisc, mCompProDisc but logic is unclear:

```vb
Dim mGoodDisc As Double
Dim mCompDisc As Double
Dim mCompProDisc As Double = 0  ' Promotion discount
```

Likely stacking order: item → group → promo → manual, but not confirmed.

---

## Sale Return / Refund (frmSaleReturn.vb)

### Trigger
Return form allows operator to refund a past sale by reference number.

### Process (presumed)
1. Look up original HistSale
2. Create return document
3. Reverse stock: `UPDATE GoodInfo SET stockOnhand = stockOnhand + returnQty`
4. Adjust points: if points were redeemed, restore them
5. Mark original sale as "returned" (saleStat = "0"?)

⚠️ **Full code not visible.** Limited to return document UI in available excerpts.

---

## Buy Exchange / Loyalty Vouchers (pAllowBuyExchange)

### Issue

When `pAllowBuyExchange = "1"`:
- Customer can purchase Buy Exchange voucher
- Creates BuyExchangeInfo record with:
  - bxCode: Unique voucher code
  - bxAmou: Voucher value
  - issueSaleNumb: Sale that issued it
  - expireDate: When voucher expires

### Redemption

- Voucher code entered at payment
- Value applied as discount or payment method
- BuyExchangeInfo updated (used flag or deleted)

**Duration:** `pDayUseBuyExchange` (days the voucher is valid)

⚠️ **Full mechanics unclear;** limited code visibility.

---

## Accounting Close / End-of-Day (frmAccoClose.vb)

### Purpose
Lock sales for a given date/branch, generate accounting batch, prevent further modifications.

### Close Entry Point

Query opens date picker; operator selects close date.

### Close Calculation

```sql
SELECT CD.cardOrder, PL.cardCode, CD.cardName, CD.cardColor, 
       SUM(PL.payAmou) as payAmou 
FROM SalePaidList PL 
INNER JOIN CardInfo CD ON CD.cardCode = PL.cardCode 
INNER JOIN HistSale HS ON HS.saleNumb = PL.saleNumb 
WHERE HS.saleStat <> '0' 
  AND HS.closeNumb = '0'  -- Not yet closed
  AND HS.saleDate = '[date]' 
  AND HS.branchCode = '[branch]'
GROUP BY CD.cardOrder, PL.cardCode, CD.cardName, CD.cardColor
ORDER BY CD.cardOrder
```

**Result:** Summary of payments by card/method for the day.

### Close Actions

1. **Generate Close Batch:** Create closeNumb (audit identifier)
2. **Update Sales:** `UPDATE HistSale SET closeNumb = '[batch]' WHERE ...`
3. **Lock Records:** Prevent modification of closed sales (mechanism unclear; possibly via UI permission check)
4. **Calculate GL Entries:** Generate debit/credit for accounting (details not in excerpts)
5. **Print Close Report:** Crystal Reports close summary

### Data Locked After Close

- HistSale cannot be voided
- SaleList cannot be edited
- Returns referencing closed sales may be rejected or require manager override

⚠️ **No Partial Close:** Appears to be all-or-nothing; if process interrupts mid-close, data may be inconsistent.

⚠️ **No Automatic Rollback:** If close fails midway, manual cleanup may be required.

---

## Stock Management

### Decrement Trigger

Stock decreases immediately when:
1. Product added to sale (frmSale) - presumed
2. Sale finalized and payment received - confirmed

### Mechanism

```sql
UPDATE GoodInfo 
SET stockOnhand[BranchCode] = stockOnhand[BranchCode] - [qty],
    lastSale[BranchCode] = '[date]'
WHERE goodCode = '[product]'
```

Called per item in SaleList.

### Minimum Stock Alert

```sql
IF GoodInfo.stockOnhand < GoodInfo.miniStock
  THEN alert operator  -- Exact UI/message not visible
```

### Stock Visibility

- Retail (branch own): uses stockOnhand[BranchCode]
- Warehouse (central): uses stockOnhand[central] or aggregate query
- Inter-branch transfer: mechanism not visible

⚠️ **No Reservation:** If two terminals both see 10 units and both try to sell 8, final stock may be negative. No pessimistic locking.

### Under-Stock Sales

If `pAllowUnderCost = "1"`:
- Allow sale even if stock insufficient
- Creates back-order or negative inventory (exact behavior unclear)

---

## Employee/Wholesale Pricing & Limits

### Employee Purchase Limit

```vb
If mEmplBuyLimit > 0 AndAlso totalSale > mEmplBuyLimit Then
  MessageBox.Show("Exceeded employee limit")
  ' Prevent sale or show warning (unclear)
End If
```

### Employee Discount

Applied per GroupInfo.emplDisc if employee customer type.

### Wholesale Pricing

If customer type = wholesale:
- Use wholesale price tier (instead of retail)
- Apply wholeDisc from GroupInfo
- Use pWholeBahtPerPoint for loyalty (lower earning rate)

---

## Tax & VAT

### VAT Rate
`pVat As Single` stored globally. Applied to sale total:
```
totalWithTax = totalPrice * (1 + pVat / 100)
```

### Tax Invoice (Optional)

If `pAllowTaxInvoice = "1"` and customer requests:
- Generate tax invoice (separate from regular receipt)
- Store in separate table (TBD; logic not visible)
- May require company tax number in HistSale

⚠️ **VAT Included:** Receipt comment states "VAT INCLUDED" - unclear if VAT is already in price or added on top.

---

## Fingerprint Access Control

### Enrollment (frmFingerPrintEnroll.vb)

```vb
' Capture fingerprint from reader
' Generate template
' Store in EmplInfo.emplFinger
' Comparison: query template against live capture
```

### Verification (Access Control)

When fingerprint enabled (`pAllowFingerScan = "1"`):
- Instead of username/password, operator scans finger
- SDK compares against EnplInfo.emplFinger
- If match: auto-login as that user
- If no match: reject or fall back to password

⚠️ **SDK Not Identified:** Device model and library not visible; presumed closed-source integration.

---

## Exchange Rate / Multi-Currency

⚠️ **Not Implemented:** All amounts in Thai Baht (THB). No exchange rate or currency conversion logic visible.

---

## Rounding Rules

### Money Rounding (DrugMod.vb)

**RoundMoney(amount, roundUp):**
```vb
' Thai 25-satang rounding: .00, .25, .50, .75 only
If amount = 123.99 AndAlso roundUp = True Then
  result = 124.00  ' Round up to nearest baht
Else If amount = 123.37 AndAlso roundUp = False Then
  result = 123.25  ' Round down to nearest .25
```

**AdjustMoney(amount):**
```vb
' Simple: .50+ rounds up, <.50 rounds down to whole baht
If amount = 123.50 Then result = 124.00
If amount = 123.49 Then result = 123.00
```

---

## Edge Cases & Gotchas

⚠️ **1-Based Array Indexing:** VB arrays are 1-based; SOAP results use: result(0), result(1), result(2), etc. Off-by-one errors likely if ported to 0-based language.

⚠️ **Nulls vs Zeros:** Empty string ("") vs 0 vs null; code uses string comparisons ("0") to detect nulls.

⚠️ **Case-Insensitive Privilege Check:** VB InStr is case-insensitive by default; if privileges are case-sensitive, port will need explicit comparison.

⚠️ **Server DateTime Sync:** pServerDateTime fetched on login and special operations; if server clock drifts, dates may be inconsistent.

⚠️ **No Optimistic Locking:** Concurrent edits not detected; last-write-wins silently.

