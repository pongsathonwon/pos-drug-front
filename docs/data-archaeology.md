# Data Archaeology

## Database Overview

**Type:** Microsoft Access 2000 (.mdb)  
**File:** `data.mdb` (located in pOffLineFolder at runtime)  
**Connection:** OleDb with Microsoft.JET.OLEDB.4.0 provider  
**Row Locking:** None (Access limitation)  
**Transactions:** IsolationLevel.ReadCommitted supported

### Two Datasets Referenced

1. **dataDataSet.xsd** - Only defines SqlText table for command queueing
2. **dsDrug.xsd** - Defines 8 read-only data views (dtXxx) for reporting/analysis

The actual application database (`data.mdb`) schema is inferred from:

- Query strings in .vb files
- Table/column names referenced in SOAP calls
- XSD-inferred tables

---

## Core Tables (Inferred from Code)

### EmplInfo (Employee/User Master)

| Column       | Type        | Nullable | Notes                                           |
| ------------ | ----------- | -------- | ----------------------------------------------- |
| emplCode     | String(4-6) | N        | Primary key; used as pUserCode                  |
| emplName     | String      | N        | Full name, may contain nickname in parentheses  |
| emplID       | String      | Y        | Alternate identifier                            |
| emplStat     | String(1)   | N        | Status: "1" = active, "0" = inactive            |
| userName     | String      | N        | Login username                                  |
| userPWD      | String      | N        | **Plaintext password**                          |
| emplPosiCode | String      | N        | Foreign key to EmplPosition                     |
| branchCode   | String      | Y        | Assigned branch (for branch-specific employees) |
| privCode     | String      | Y        | Privilege/role code (e.g., "PHFRA")             |
| emplFinger   | ?           | Y        | Fingerprint template (presumed)                 |
| dateStamp    | Date        | Y        | Last clock timestamp                            |
| inTime       | String      | Y        | Clock-in time                                   |
| inBranchCode | String      | Y        | Clock-in branch                                 |

**Relationships:**

- FK: emplPosiCode → EmplPosition.emplPosiCode

**Used By:**

- Login: frmLogIn.vb, frmPass.vb
- Password change: frmChangePassword.vb
- Payroll/HR: implied by time clock fields

---

### EmplPosition (Position Codes)

| Column       | Type   | Nullable | Notes                                          |
| ------------ | ------ | -------- | ---------------------------------------------- |
| emplPosiCode | String | N        | Primary key                                    |
| emplPosiName | String | N        | Position title (e.g., "Pharmacist", "Cashier") |

**Relationships:**

- Referenced by: EmplInfo.emplPosiCode

---

### GoodInfo (Product Master)

| Column                      | Type      | Nullable | Notes                                                                          |
| --------------------------- | --------- | -------- | ------------------------------------------------------------------------------ |
| goodCode                    | String(6) | N        | Primary key; product identifier                                                |
| goodName                    | String    | N        | Product name in Thai                                                           |
| goodStat                    | String(1) | N        | Status: "1" = active, "0" = inactive                                           |
| drugCode                    | String    | Y        | Drug classification code                                                       |
| cateCode                    | String    | Y        | Category code (FK to GoodCategory)                                             |
| typeCode                    | String    | Y        | Type code (FK to GoodType)                                                     |
| groupCode                   | String    | Y        | Group code (FK to GroupInfo)                                                   |
| noBranchStock               | String    | Y        | Flag: limit stock by branch                                                    |
| allowUnderCost              | String    | Y        | Flag: allow sale below cost                                                    |
| stickerPrice                | Double    | Y        | Ceiling price (cannot exceed)                                                  |
| fixPrice                    | String(1) | Y        | Flag: "1" = price is fixed                                                     |
| **stockOnhand[BranchCode]** | Integer   | Y        | Current stock per branch (dynamic columns: stockOnhand01, stockOnhand02, etc.) |
| **miniStock[BranchCode]**   | Integer   | Y        | Minimum stock threshold per branch                                             |
| **stockCount[BranchCode]**  | Integer   | Y        | Physical count per branch                                                      |
| **lastSale[BranchCode]**    | Date      | Y        | Last sale date per branch                                                      |
| **unitCost[BranchCode]**    | Double    | Y        | Cost per unit per branch                                                       |
| **price1**                  | Double    | Y        | Retail price tier 1                                                            |
| **price2**                  | Double    | Y        | Retail price tier 2                                                            |
| **price3**                  | Double    | Y        | Retail price tier 3                                                            |
| **price4**                  | Double    | Y        | Retail price tier 4                                                            |
| **price5**                  | Double    | Y        | Retail price tier 5                                                            |
| **price6**                  | Double    | Y        | Retail price tier 6                                                            |

⚠️ **EAV Pattern Detected**: Stock and pricing data stored as separate columns per branch/tier, not normalized rows.

**Formula:** Used in pricing tier selection:

- `pBranchPrice` (global) determines which `price[N]` column to use
- Per-branch stock lookups: `"stockOnhand" & pBranchCode`

**Used By:**

- All product lookups (sales, inventory, reports)

---

### GoodBarcode (Product SKU / Pack Variants)

| Column   | Type    | Nullable | Notes                                         |
| -------- | ------- | -------- | --------------------------------------------- |
| barCode  | String  | N        | Primary key; barcode value (EAN-13 or custom) |
| goodCode | String  | N        | Foreign key to GoodInfo                       |
| unitCode | String  | N        | Foreign key to UnitInfo; unit of measure      |
| goodAmou | Integer | N        | Quantity per pack (e.g., 1, 10, 100)          |

**Relationships:**

- FK: goodCode → GoodInfo.goodCode
- FK: unitCode → UnitInfo.unitCode

**Examples:**

- 1 tablet (goodAmou=1) vs. 1 box of 10 tablets (goodAmou=10) have different barcodes but same goodCode

**Used By:**

- Barcode scanning in sales
- Price matrix construction

---

### UnitInfo (Unit of Measure)

| Column     | Type    | Nullable | Notes                                                     |
| ---------- | ------- | -------- | --------------------------------------------------------- |
| unitCode   | String  | N        | Primary key                                               |
| unitDesc   | String  | N        | Description (Thai): "เม็ด" (tablet), "ขวด" (bottle), etc. |
| unitFactor | Integer | N        | Conversion: goodAmou \* unitFactor = individual units     |

**Example:**

- unitCode="10", unitDesc="ขวด (Bottle)", unitFactor=10 tablets per bottle

---

### GroupInfo (Product Group / Category Hierarchy)

| Column    | Type   | Nullable | Notes                        |
| --------- | ------ | -------- | ---------------------------- |
| groupCode | String | N        | Primary key                  |
| groupDesc | String | N        | Group name (Thai)            |
| fromGP    | Double | Y        | Gross profit lower bound (%) |
| toGP      | Double | Y        | Gross profit upper bound (%) |
| membDisc  | Double | Y        | Member discount (%)          |
| emplDisc  | Double | Y        | Employee discount (%)        |
| wholeDisc | Double | Y        | Wholesale discount (%)       |

**Used By:**

- Discount calculation in sales
- GP/margin analysis

---

### CustInfo (Customer Master)

| Column       | Type      | Nullable | Notes                                           |
| ------------ | --------- | -------- | ----------------------------------------------- |
| custCode     | String    | N        | Primary key                                     |
| custName     | String    | N        | Customer name (Thai)                            |
| custTypeCode | String    | N        | Foreign key to CustType                         |
| custStat     | String(1) | N        | Status: "1" = active                            |
| custAddr     | String    | Y        | Address (Thai)                                  |
| custPhone    | String    | Y        | Phone number                                    |
| custEmail    | String    | Y        | Email (validated with IsValidEmailFormat regex) |
| custBirth    | Date      | Y        | Date of birth                                   |
| custJoinDate | Date      | Y        | Membership join date                            |
| custPoint    | Integer   | Y        | Current loyalty points balance                  |

**Relationships:**

- FK: custTypeCode → CustType.custTypeCode

**Used By:**

- Sales (customer lookup, points calculation, allergy checking)
- Membership reports

---

### CustType (Customer Category)

| Column       | Type      | Nullable | Notes                                              |
| ------------ | --------- | -------- | -------------------------------------------------- |
| custTypeCode | String(1) | N        | Primary key; single digit                          |
| custTypeDesc | String    | N        | Type name (e.g., "Regular", "Member", "Wholesale") |

**Examples (inferred):**

- "1" = Regular retail customer
- "2" = Member (loyalty program)
- "6" = HUG Club member (special handling in receipts)
- "W" = Wholesale buyer

---

### HistSale (Sales Transaction Header)

| Column      | Type       | Nullable | Notes                                                                   |
| ----------- | ---------- | -------- | ----------------------------------------------------------------------- |
| saleNumb    | String(15) | N        | Primary key; format: PREFIX + POSPNO + YEAR + SEQNUMB                   |
| saleDate    | Date       | N        | Sale date                                                               |
| saleTime    | String     | N        | Sale time (HH:MM format)                                                |
| branchCode  | String     | N        | Issuing branch                                                          |
| custCode    | String     | N        | Foreign key to CustInfo                                                 |
| emplCode    | String     | N        | Foreign key to EmplInfo (sales person)                                  |
| cashCode    | String     | N        | Foreign key to EmplInfo (cashier)                                       |
| totalPrice  | Double     | N        | Subtotal before discount                                                |
| totalDisc   | Double     | N        | Total discount amount                                                   |
| totalCost   | Double     | N        | Total cost of goods                                                     |
| totalPay    | Double     | N        | Final payment due (after discount)                                      |
| totalCash   | Double     | N        | Amount paid in cash                                                     |
| totalCredit | Double     | N        | Amount paid via card/credit                                             |
| totalDebt   | Double     | N        | Outstanding balance (0 if paid in full)                                 |
| totalCupong | Double     | N        | Coupon/voucher amount                                                   |
| perCharge   | Double     | N        | Service charge / fee                                                    |
| payType     | String(1)  | N        | "C" = cash, "D" = debit/credit card                                     |
| creditCode  | String     | Y        | Foreign key to CardInfo (if credit)                                     |
| creditNumb  | String     | Y        | Credit card / reference number                                          |
| saleStat    | String(1)  | N        | Status: "1" = completed, "0" = voided/canceled                          |
| closeNumb   | String     | Y        | Associated accounting close number                                      |
| saleRema    | String     | Y        | "offline" = from offline sync                                           |
| flag        | String(1)  | Y        | **Offline sync flag**: "1" = unsync, "2" = synced (in offline.mdb only) |

**Relationships:**

- FK: custCode → CustInfo.custCode
- FK: emplCode → EmplInfo.emplCode (salesperson)
- FK: cashCode → EmplInfo.emplCode (cashier)
- FK: creditCode → CardInfo.cardCode

**Used By:**

- Sales reporting
- Offline synchronization (frmUploadServer.vb)
- Accounting close

---

### SaleList (Sales Transaction Line Items)

| Column    | Type       | Nullable | Notes                                     |
| --------- | ---------- | -------- | ----------------------------------------- |
| saleNumb  | String(15) | N        | FK to HistSale.saleNumb (composite PK)    |
| itemNo    | Integer    | N        | Line item sequence (composite PK)         |
| barCode   | String     | N        | Product barcode                           |
| goodCode  | String     | N        | Product code                              |
| goodAmou  | Integer    | N        | Quantity sold                             |
| unitCode  | String     | N        | Unit of measure                           |
| unitPrice | Double     | N        | Unit selling price (after tier selection) |
| unitCost  | Double     | N        | Unit cost (from GoodInfo)                 |
| subDisc   | Double     | N        | Line-item discount                        |

⚠️ **unitPrice stored in transaction**: Allows price history (what was charged, not current price)

**Relationships:**

- FK: saleNumb → HistSale.saleNumb

**Used By:**

- Detailed receipt printing
- Returns processing
- Offline sync

---

### HistSalePro (Loyalty Points Earned/Redeemed)

| Column      | Type       | Nullable | Notes                                 |
| ----------- | ---------- | -------- | ------------------------------------- |
| saleNumb    | String(15) | N        | FK to HistSale.saleNumb               |
| thisPoint   | Integer    | Y        | Points earned this transaction        |
| usePoint    | Integer    | Y        | Points redeemed this transaction      |
| remainPoint | Integer    | Y        | Balance after transaction             |
| pointDisc   | Double     | Y        | Discount amount from point redemption |
| extraPoint  | Integer    | Y        | Bonus points (promotions)             |

**Used By:**

- Points calculation and reporting
- HUG Club member receipts

---

### SalePaidList (Payment Methods)

| Column   | Type       | Nullable | Notes                                    |
| -------- | ---------- | -------- | ---------------------------------------- |
| saleNumb | String(15) | N        | FK to HistSale.saleNumb                  |
| cardCode | String     | N        | FK to CardInfo.cardCode ("0" = cash)     |
| payAmou  | Double     | N        | Amount paid via this method              |
| refNumb  | String     | Y        | Reference number (credit card auth code) |

**Example:**

- Same sale might have: ("0", 500) for cash, ("CC", 300) for credit card

**Relationships:**

- FK: cardCode → CardInfo.cardCode

---

### CardInfo (Payment Method Master)

| Column    | Type    | Nullable | Notes                                                             |
| --------- | ------- | -------- | ----------------------------------------------------------------- |
| cardCode  | String  | N        | Primary key                                                       |
| cardName  | String  | N        | Display name (Thai): "เงินสด" (Cash), "บัตรเครดิต" (Credit), etc. |
| cardColor | String  | Y        | UI color for button display                                       |
| cardOrder | Integer | Y        | Display sequence                                                  |

---

### DrugAllergic (Allergy Cross-Reference)

| Column   | Type   | Nullable | Notes                    |
| -------- | ------ | -------- | ------------------------ |
| custCode | String | N        | FK to CustInfo.custCode  |
| drugCode | String | N        | FK to DrugGroup.drugCode |

**Used By:**

- Allergy checking during sales (frmSale.vb line 365)
- Alert if purchased drug in customer's allergy list

---

### DrugGroup (Drug Classification)

| Column   | Type   | Nullable | Notes                   |
| -------- | ------ | -------- | ----------------------- |
| drugCode | String | N        | Primary key             |
| drugDesc | String | N        | Drug description (Thai) |

**Used By:**

- Allergy checking: linked from GoodInfo.drugCode

---

### SalePro (Promotion Definition)

| Column       | Type      | Nullable | Notes                                          |
| ------------ | --------- | -------- | ---------------------------------------------- |
| proNo        | String    | N        | Primary key                                    |
| proDesc      | String    | N        | Promotion description (Thai)                   |
| proStat      | String(1) | N        | Status: "0" = inactive, else active            |
| branchCode   | String    | N        | "0" = all branches, else specific              |
| branchPrice  | String    | N        | "0" = all price tiers, else specific           |
| startDate    | Date      | N        | Promo start date                               |
| endDate      | Date      | N        | Promo end date                                 |
| buyPrice     | Double    | Y        | Minimum purchase amount to trigger             |
| custTypeCode | String    | Y        | Applies to specific customer type (null = all) |
| freeMember   | String(1) | Y        | "1" = free membership promo                    |
| extraPoint   | Integer   | Y        | Bonus points                                   |
| plusPoint    | Integer   | Y        | Additional points multiplier                   |

**Used By:**

- Promotion loading on form load (frmSale.vb line 125)
- Discount/points calculation

---

### BranchInfo (Branch Master)

| Column                 | Type    | Nullable | Notes                                      |
| ---------------------- | ------- | -------- | ------------------------------------------ |
| branchCode             | String  | N        | Primary key                                |
| branchName             | String  | N        | Branch name (Thai)                         |
| saleNumb               | Integer | N        | **Running counter** for document numbering |
| ... (other fields TBD) |         |          |                                            |

**Used By:**

- Sale numbering sequence (frmUploadServer.vb line 73)
- Offline sync increments this: `UPDATE BranchInfo SET saleNumb = saleNumb + 1`

---

### BuyExchangeInfo (Loyalty Exchange Vouchers)

| Column        | Type    | Nullable | Notes                         |
| ------------- | ------- | -------- | ----------------------------- |
| bxCode        | String  | N        | Voucher code                  |
| bxAmou        | Integer | Y        | Value of voucher              |
| issueSaleNumb | String  | Y        | Sale that issued this voucher |
| expireDate    | Date    | Y        | Voucher expiration date       |

⚠️ Not fully documented; limited visibility in code.

---

### LogRecord (Audit Log)

| Column           | Type   | Nullable | Notes                                          |
| ---------------- | ------ | -------- | ---------------------------------------------- |
| branchCode       | String | N        | Branch of login                                |
| logSession       | String | N        | Session ID (BranchCode + emplCode + Timestamp) |
| logInDate        | String | N        | Login date (M/D/YYYY format from MDYStr)       |
| logInTime        | String | N        | Login time (HH:MM format)                      |
| emplCode         | String | N        | Employee code                                  |
| drugFrontVersion | String | Y        | App version at login                           |

**Notes:**

- Only non-admin logins logged (admin emplCode="5" skipped)
- Used for audit trail

---

### ETimeStamp (Employee Time Clock - Offline)

| Column     | Type      | Nullable | Notes                                  |
| ---------- | --------- | -------- | -------------------------------------- |
| emplCode   | String    | N        | Employee code                          |
| dateStamp  | Date      | N        | Clock date                             |
| inTime     | String    | N        | Clock-in time (HH:MM)                  |
| outTime    | String    | N        | Clock-out time (HH:MM)                 |
| branchCode | String    | Y        | Clock location                         |
| flag       | String(1) | Y        | Sync flag (offline only): "1" = unsync |

**Used By:**

- Offline time clock (employee check-in/out)
- Sync to server (frmUploadServer.vb lines 248-270)

---

### SqlText (Offline Command Queue - dataDataSet)

| Column   | Type                  | Notes                       |
| -------- | --------------------- | --------------------------- |
| saleNumb | String(20)            | FK composite with itemNo    |
| itemNo   | Int16                 | FK composite with saleNumb  |
| cmdText  | String (LongVarWChar) | SQL command text to execute |
| itemStat | String(1)             | Status flag                 |

**Purpose:** Queue SQL commands during offline operation for later execution on server.

**XSD Definition:** From dataDataSet.xsd, lines 14-81

---

### FrontCard (Stock Movement Audit)

| Column      | Type    | Nullable | Notes                                                            |
| ----------- | ------- | -------- | ---------------------------------------------------------------- |
| stockDate   | Date    | N        | Transaction date                                                 |
| stockTime   | String  | N        | Transaction time                                                 |
| workType    | String  | N        | "OSL" = offline sale, "SAL" = normal sale, "REC" = receipt, etc. |
| branchCode  | String  | N        | Location                                                         |
| docNumb     | String  | N        | Reference document (sale number, receipt number)                 |
| emplName    | String  | N        | Employee name (truncated to 10 chars in uploads)                 |
| goodCode    | String  | N        | Product code                                                     |
| goodAmou    | Integer | N        | Quantity moved                                                   |
| stockOnhand | Integer | N        | Stock after movement                                             |

**Created By:**

- frmUploadServer.vb during offline sync (line 211): `INSERT INTO FrontCard (... VALUES (... 'OSL' ...)`
- Appears to be readonly audit trail

---

## Reporting DataSets (dsDrug.xsd)

These are read-only DataViews for reporting, not write-back:

### dtGoodNotMove

- goodName, barCode, goodAmou, unitDesc, lastSale, unitCost
- Products with no recent sales

### dtBranchSaleByGroup

- saleDate, groupDesc, totalPrice
- Sales by product group per branch

### dtHistBranchReturn

- retuNumb, retuDate, barCode, goodName, goodAmou, unitPrice, retuRema
- Return transactions

### dtPushConClude

- goodName, groupName, pushType, pushRange, totalPushAmou, targetAmou, totalSaleAmou, saleFactor, monthTarget
- Push/target sales campaign metrics

### dtHistSaleSum

- branchName, custTypeDesc, totalCost, totalSale, totalBill, saleDate, saleDateSort
- Sales summary by branch and customer type

### dtHistSaleType

- branchZoneDesc, branchName, salePriceType, totalCost, totalSale, totalBill, saleDate, saleDateSort
- Sales by price tier

### dtMonthGoodUse

- groupName, goodName, stockOnhand, stockCost, salePerMonth, monthUseIndex, lastSale, noSale
- Monthly usage analysis

### dtStockOnhand

- goodName, unitDesc, typeDesc, stockOnhand, totalCost, barCode, unitCost, unitPrice, GP, shelfNo
- Current inventory snapshot

### dtFCSale

- salePeriod, totalSale, totalCost, totalBill, avgBill, perGP
- Financial close summary (period-based)

### dtAccBook11, dtAccoBook9

- Accounting ledger formats for GL reporting

---

## Summary: Key Design Patterns

### 1. Dynamic Column Pattern (EAV-like)

```sql
GoodInfo has columns: stockOnhandXX, lastSaleXX, unitCostXX
where XX = branch code (01, 02, 03, etc.)
and priceN where N = tier (1-6)
```

Allows per-branch inventory without row multiplication.

### 2. String-Based Codes

- All primary keys and foreign keys are strings
- No auto-increment integers (except itemNo in SaleList)
- Allows manual numbering and human-readable IDs

### 3. Flag-Based Status

- Column names: `*Stat`, `*Status`, `flag`
- Values: "0" or "1" (string, not boolean)
- Used for: active/inactive, sync status, completion status

### 4. Offline Sync via Flag

- HistSale.flag = "1" (unsync), "2" (synced)
- ETimeStamp.flag = "1" (unsync)
- Allows tracking of which offline records need upload

### 5. Plaintext Sensitive Data

- Passwords stored as-is (NO HASHING)
- Privilege codes as concatenated strings
- Credit card numbers (possibly, unverified)

---

## Missing / Ambiguous Columns

Several referenced in code but not fully documented:

| Table      | Column       | Status     | Notes                                |
| ---------- | ------------ | ---------- | ------------------------------------ |
| GoodInfo   | shelfNo      | Inferred   | Product shelf location               |
| EmplInfo   | emplFinger   | Inferred   | Fingerprint template (binary?)       |
| SalePro    | custTypeCode | Partially  | Can be null (applies to all types?)  |
| BranchInfo | (many)       | Incomplete | Tax number, address fields TBD       |
| HistSale   | closeNumb    | Inferred   | Links to accounting close batch      |
| CustInfo   | custPoint    | Inferred   | Points balance (or via HistSalePro?) |

---

## Data Type Anomalies

⚠️ **String Dates in SQL:**
All dates are converted to string in queries using `MDYStr()`:

```vb
"WHERE saleDate = '" & MDYStr(pServerDateTime) & "'"
```

This requires Access to parse the string back to date. Fragile if locale differs.

⚠️ **Mixed Numeric Types:**

- `totalPrice`, `totalDisc` → Double
- `goodAmou`, `stockOnhand` → Integer
- But some calculations may truncate if done in wrong order

⚠️ **Column Name Assumptions:**
Stock fields (`stockOnhandXX`) assume branch code is always 2 digits. If 3-digit codes are added, queries break.
