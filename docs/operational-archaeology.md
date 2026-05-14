# Operational Archaeology

## Global State (DrugMod.vb Public Variables)

The entire system's runtime state is stored as public module-level variables in `DrugMod.vb`. This is the "session" and must be mapped to a scoped session object in v2.

### SOAP Service References

- `pService As New MyService.Service` - Primary SOAP service proxy
- `pService2 As New MyService2.Service` - Secondary SOAP service proxy
- `pService3 As New MyService3.Service` - Tertiary SOAP service proxy
- `pServiceAddr As String` - Service address parameter
- `pServerAddr As String` - Server address (hardcoded in app.config)
- `pNewServerAddr As String` - New server address (for configuration changes)

### Configuration & Deployment

- `pProgCode As String = "PHFR"` - Program identifier code
- `pAppName As String = "DrugFront"` - Application name
- `pCurrentVersion As String` - Runtime version
- `pBranchCode As String` - Branch identifier (critical session variable)
- `pBranchIndex As Integer` - Branch lookup index
- `pBranchName As String` - Display branch name
- `pBranchAddress As String` - Branch address
- `pBranchPhone As String` - Branch contact
- `pBranchPrice As String` - Price tier identifier (e.g. "1", "2", "3")
- `pBranchTypeCode As String` - Branch type code
- `pPOSNo As String` - Thai comment: "เลขที่เครื่อง pos ตามใบการค้า"
- `pPOSNumber As String` - Thai comment: "ตัวเลขเครื่องเอกสาร"
- `pIsFranchise As String` - Thai comment: "โปรแกรมร้านแฟชไรส์"

### Company & Organization

- `pCompName As String`, `pCompName1 As String` - Company name variants
- `pCompAddress As String`, `pCompAddr1 As String`, `pCompAddr2 As String` - Address fields
- `pCompFullName As String` - Full legal company name
- `pCompTaxNumber As String` - Tax ID
- `pVat As Single` - VAT rate
- `pHugName As String` - "Hug" organization name (parent/head office?)
- `pHugAddress As String` - Hug address
- `pHugTaxNumber As String` - Hug tax ID
- `pTaxBranchNo As String` - Tax branch number

### Pricing & Discount Configuration

- `pBranchPrice As String` - Determines which price field to use (column "priceN" in GoodBarcode)
- `pWholePriceLevel As String` - Whole price tier identifier
- `pOnlinePriceLevel As String` - Online price tier
- `pAllowWholePrice As String` - Flag: "1" = show whole price column in UI
- `pAllowOnlinePrice As String` - Flag: "1" = allow online pricing
- `pAllowO2OSale As String` - Flag: online-to-offline sales
- `pAllowTaxInvoice As String` - Flag: "1" = show tax invoice option
- `pAllowDisc As String` - Flag: allow manual discount
- `pAllowDiscEnter As String` - Flag: allow discount data entry
- `pAllowOnlyMembPrice As String` - Thai comment: "ใช้ราคาแต่ละสมาชิก รับชำระเฉพาะ" - affects UI visibility of price tiers
- `pMembPrice As Double` - Member price value
- `pMembExtraPoint As Integer` - Thai comment: "คะแนนพิเศษสำหรับสมาชิก" - extra points for member
- `pPerPrice1ToPrice0 As Integer` - Percentage adjustment from price1 to price0 (used in frmSale.vb line 312)

### Numbering & Document Control

- `pPreSaleNumb As String` - Prefix for sale document number
- `pPreReturnNumb As String` - Prefix for return number
- `pPreTaxInvoiceNumb As String` - Prefix for tax invoice number
- `pLogSession As String` - Current session identifier (format: BranchCode + UserCode + Timestamp)

### Authentication & Authorization

- `pUserCode As String` - Employee code (unique identifier, becomes part of pLogSession)
- `pUserName As String` - Employee name (display name)
- `pUserPosition As String` - Position title
- `pUserID As String` - Employee ID
- `pUserPriv As String` - Privilege/role code string (contains program codes like "PHFR")
- `pUserImage As PictureBox` - User avatar/photo control

### Offline Operation

- `pOffLineFolder As String` - Path to offline database directory
- `pOfflineUpdate As Boolean` - Offline mode flag
- `pOfflineDate As Date` - Offline mode activation date
- `pRegistry As String` - Registry base path

### Features & Permission Flags

- `pAllowFingerScan As String` - Flag: "1" = enable fingerprint authentication
- `pAllowCheckCostAndPrice As String` - Flag: audit cost vs selling price
- `pAllowBuyExchange As String` - Thai comment: "ใบแลกซื้อ" - exchange voucher feature
- `pAllowEmplPro As String` - Thai comment: "ส่วนลด/ส่วนแบ่งพนักงาน"
- `pBillPrint As String` - Receipt printing configuration
- `pBranchGroupCode As String` - Branch group classification

### Printer & Hardware

- `pPrinterPort As String` - Receipt printer port (LPT1, COM, network, etc.)
- `pDefaultReportPrinterName As String` - Crystal Reports default printer

### Server Synchronization

- `pServerDateTime As Date` - Current server time (fetched on login)
- `pStartDateLimit As Date` - Start date for data validation
- `pEndDateLimit As Date` - End date for data validation
- `pAutoUploadSale As Boolean` - Automatic sync on transaction completion

### Loyalty Points & Membership

- `pBirthPointPlus As Integer` - Points multiplier on birthdays
- `pBahtPerPoint As Integer` - Conversion rate: 1 point per X baht (retail)
- `pWholeBahtPerPoint As Integer` - Conversion rate for wholesale

### Inventory & Stock

- `pEmplBuyLimit As Double` - Employee purchase limit amount
- `pIsBranchShipTo As Boolean` - Branch acts as ship-to location
- `pPricePerOneBuyExchange As Integer` - Thai comment: "ราคาสำหรับดำเนินการแลกซื้อ"
- `pDayUseBuyExchange As Integer` - Thai comment: "วันการใช้แลกซื้อ" (days valid)
- `pShiptoPOLifespan As Integer` - PO validity duration

### Display & UI

- `pScreenRatio As String` - Screen resolution indicator (e.g. "4:3")
- `pMessageBox As MyMessageBox` - Custom message box component

### Data Structures

```vb
Structure GoodType
    Dim Description As String
    Dim Code As String
End Structure

Public pGoodType() As GoodType  ' Array of product types

Structure GoodShelf
    Dim ShelfNo As String
End Structure

Public pGoodShelf() As GoodShelf  ' Array of shelf numbers
```

---

## Error Code Convention

All SOAP operations return String arrays with a 3-part structure:

| Return(0) | Meaning | Details |
|-----------|---------|---------|
| "1" | Success | Following array elements contain data |
| "0" | No records | Data not found; Return(1) contains detail message |
| "-1" | Error | An exception occurred; Return(1) contains error message |

**Pattern:**
```vb
Dim mGet() As String
mGet = pService.GetData("Drug", sqlQuery)
If mGet(0) = "1" Then
  ' Success - mGet(1), mGet(2), etc. contain columns
Else
  ' Failure - mGet(1) contains message
End If
```

⚠️ 116 instances of this pattern found across 29 files. All call sites must be audited.

---

## SOAP Service Operations Pattern

All calls follow this pattern:
```vb
pService.GetData(entityName, sqlString) -> String()
pService.UpdateData(entityName, sqlArray) -> String
pService.SelectData(entityName, sqlString) -> DataSet
```

**Hardcoded Server IPs in app.config:**
- `http://203.151.212.20/MyService/Service.asmx` - Primary service (MyService & MyService2)
- `http://110.170.201.18/MyService3/service.asmx` - Alternative service (MyService3)

⚠️ **SQL Injection Risk**: Every pService.GetData() call constructs SQL via string concatenation. Examples:
- `"SELECT ... WHERE userName = '" & txtUserName.Text & "'"`
- `"SELECT ... WHERE goodCode = '" & GoodCode & "'"`
- No parameterized queries; all inputs pass directly to SQL.

---

## Offline Mechanism (frmUploadServer.vb)

### Detection & Entry

1. When server is unreachable, `pService` calls fail
2. System writes transactions to local `pOffLineFolder & "data.mdb"` using `UpdateData()` with local connection
3. Operator manually initiates sync via "Upload Server" form

### Offline Data Storage

Local .mdb database stores:
- `HistSale` table - Sales transactions with `flag` column (values: "1" = unsync, "2" = synced)
- `SaleList` table - Line items for sales
- `ETimeStamp` table - Employee time clock records (in/out)
- `SqlText` table - Queued SQL commands

### Upload Flow

1. Check if offline data exists: `SELECT count(*) FROM HistSale WHERE flag = '1'`
2. Fetch next sale number from server: `pService.GetData("Drug", "SELECT saleNumb FROM BranchInfo WHERE branchCode = '...'")` 
3. For each offline sale:
   - Generate new server sale number: `pPreSaleNumb & Mid((100000 + mNumb).ToString, 2)`
   - Insert into server HistSale with `saleRema = 'offline'` 
   - Insert each SaleList item
   - Update GoodInfo stock levels
   - Insert FrontCard (stock movement audit log)
4. Mark local record as synced: `UPDATE HistSale SET flag = '2' WHERE ...`

⚠️ **Conflict Resolution**: None. Last-write-wins. If server deletes/updates a sale before upload completes, data is lost or corrupted.

⚠️ **No Transactional Guarantee**: Upload is not atomic across server and offline DB. If process crashes mid-upload, records may be partially synced and re-uploaded on next attempt, creating duplicates.

⚠️ **Concurrent Terminal Sync**: No lock mechanism. Multiple terminals uploading simultaneously to same branch can generate duplicate sale numbers.

---

## Login Flow (frmLogIn.vb)

1. User enters username and password
2. Query: `SELECT EI.emplCode, EI.emplName, EI.emplID, EI.privCode, EP.emplPosiName FROM EmplInfo EI INNER JOIN EmplPosition EP ... WHERE EI.emplStat = '1' AND EI.userName = '...' AND EI.userPWD = '...'`
3. ⚠️ **Plaintext password comparison** in SQL WHERE clause (no hashing)
4. If found (mGet(0) = "1"):
   - Set global: `pUserCode = mGet(1)` (emplCode)
   - Set global: `pUserName = RemoveNickName(mGet(2))` (emplName)
   - Set global: `pUserID = mGet(3)` (emplID)
   - Set global: `pUserPriv = mGet(4)` (privCode)
   - Set global: `pUserPosition = mGet(5)` (emplPosiName)
   - **If not admin (pUserCode ≠ "5")**:
     - Fetch server time: `pServerDateTime = pService.ServerDateTime`
     - Generate session ID: `pLogSession = pBranchCode & pUserCode & Format(pServerDateTime, "ddMMyyHHmmss")`
     - Insert into LogRecord: `INSERT INTO LogRecord (branchCode, logSession, logInDate, logInTime, emplCode, drugFrontVersion)`
5. If not found (mGet(0) ≠ "1"): Show error "Username/password incorrect"

---

## Permission Checking Pattern

Example from frmSale.vb line 202:
```vb
If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
  Exit Sub
End If
```

- `pUserPriv` is a string of privilege codes
- `Me.Tag` contains the form's permission code
- Example privilege format: "PHAAPFPR" where:
  - "PHA" = program code (PHFR shortened?)
  - "A" = Add permission
  - "P" = possibly another permission type
- ⚠️ **Case-sensitive search** using VB InStr (case-insensitive in VB by default) - must verify if intent is case-sensitive

---

## Offline Fallback Logic

Located in multiple forms (frmSale.vb, etc.) and DrugMod functions:

### Local .mdb Access Functions

**SelectData(sqlText) / GetData(sqlText)**
- Uses local path: `"Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & "data.mdb"`
- Returns DataSet / String array respectively
- No server required

**UpdateData(sqlTextArray, datafile)**
- Executes array of SQL statements in transaction
- datafile parameter: "data.mdb" for local, configurable for others
- Returns "1" on success, error message otherwise
- Uses IsolationLevel.ReadCommitted

**SelectDataOff(sqlText) / GetDataOff(sqlText) / UpdateDataOff(sqlTextArray)**
- Hardcoded local path: `"Data Source=data.mdb"` (relative path!)
- Used when explicitly offline mode detected

⚠️ **Path Ambiguity**: Some functions use absolute path `pOffLineFolder & "data.mdb"`, others use relative "data.mdb". If working directories differ, app may access wrong database.

---

## Date Format Handling

Thai date localization is hardcoded throughout:

- `MDYStr(date)` -> "M/D/YYYY" format (e.g., "1/15/2024")
- `YMDStr(date)` -> "YYYY/M/D" format
- `DMYStr(date)` -> "D/M/YYYY" format
- `ThaiDate(date)` -> "15  มกราคม  2567" (day + Thai month name + Thai year)
- `ThaiShortDate(date)` -> "15  ม.ค.  2567" (abbreviated Thai month)
- `ThaiNumbDate(date)` -> "15/01/2567" (numeric with Thai year + 543)

Thai year calculation: `mDate.Year + 543` (Buddhist calendar is 543 years ahead)

All these are called in SQL string construction directly -> SQL injection vulnerability if date format assumption is wrong.

---

## Transaction Handling

**DrugMod.UpdateData()** (lines 464-494):
```vb
Dim trans As OleDb.OleDbTransaction = objConnect.BeginTransaction(IsolationLevel.ReadCommitted)
For Each sql in sqlTextArray
  objCommand.ExecuteNonQuery()
Next
trans.Commit()  ' Or trans.Rollback() on exception
```

All-or-nothing semantics: any single statement failure rolls back entire batch.

---

## GoodStock Class (Temporary Data Container)

```vb
Class GoodStock
    Public stockOnhand As Integer
    Public miniStock As Integer
    Public stockCount As Integer
    Public lastSale As Date
    Public unitCost As Double
    Public shelfNo As String
End Class
```

Used to fetch product stock info from server/offline.

---

## Money Formatting Functions

- `RoundMoney(amount, roundUp)` - Rounds to .00, .25, .50, .75 increments (Thai 25-satang rounding)
- `AdjustMoney(amount)` - Rounds to nearest baht (.50 and above round up)
- `MyVal(text)` - Parse decimal: removes commas, handles empty string as 0
- `MoneyToWord(amount)` - Converts numeric to Thai text (e.g., 123.45 -> "หนึ่งร้อยยี่สิบสามบาท สี่สิบห้าสตางค์")

---

## Summary of Session State Dependencies

To port v2 correctly, these globals must become instance variables in a scoped Session object:

**Critical (Must have before any form works):**
- pUserCode, pUserName, pUserPriv, pUserPosition - Auth identity
- pBranchCode, pBranchPrice - Domain routing
- pServerAddr - Service endpoint
- pServerDateTime - Server time sync

**Configuration (Loaded at startup):**
- pCompName, pVat, pTaxBranchNo - Company details
- pAllowDisc, pAllowFingerScan, etc. - Feature flags
- pBirthPointPlus, pBahtPerPoint - Points rules
- pPreSaleNumb, pPreReturnNumb - Document numbering

**Runtime (Changes during session):**
- pLogSession - Audit trail ID
- pOfflineUpdate, pOfflineDate - Offline mode indicators
- pServerDateTime - Updated on each sync

