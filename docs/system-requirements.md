# System Requirements & Infrastructure

## Server Endpoints

### Primary SOAP Services

**MyService (MyService.Service):**
- URL: `http://203.151.212.20/MyService/Service.asmx`
- Protocol: HTTP (unencrypted)
- Used for: Drug, inventory, customer, transaction operations
- Methods referenced:
  - `GetData(entityName, sqlString)` → String()
  - `UpdateData(entityName, sqlArray)` → String
  - `SelectData(entityName, sqlString)` → DataSet
  - `ServerDateTime` (property)

**MyService2 (MyService2.Service):**
- URL: `http://203.151.212.20/MyService/Service.asmx` (same as MyService)
- Purpose: Unknown; appears to be fallback or alternate interface

**MyService3 (MyService3.Service):**
- URL: `http://110.170.201.18/MyService3/service.asmx`
- Used for: Not clear from code excerpts; separate domain suggests alternate service

### Configuration Location

- File: `app.config` in application root
- Section: `<applicationSettings><DrugFront.My.MySettings>`
- Change Method: Recompile and redeploy (not runtime configurable)

⚠️ **No Runtime Configuration:** IPs hardcoded in app.config; cannot be changed without recompilation.

---

## Local Database

### Offline Mode Storage

**Type:** Microsoft Access 2000 (.mdb)

**Location:** `pOffLineFolder` global variable (configured at startup, likely from registry or config)

**Files:**
- `data.mdb` - Main offline cache (same schema as server)
- `data.mdb` (copy in offline folder) - Backup for sync

### Connection String

```
Provider=Microsoft.JET.OLEDB.4.0;Data Source=[path]\data.mdb;Persist Security Info=False
```

### Characteristics

- 32-bit OLEDB provider required (no 64-bit support)
- No built-in row-level locking
- Transactions: IsolationLevel.ReadCommitted supported
- Maximum size: 2GB per .mdb file

⚠️ **32-bit Limitation:** If app runs on 64-bit system without 32-bit Office drivers, offline mode fails.

---

## Hardware Integration

### Fingerprint Reader

**Device:** Not identified in code

**SDK/Library:** Closed-source; integrated via COM or native bridge

**Usage:**
- `frmFingerPrintEnroll.vb` - Enrollment flow
- `frmLogIn.vb` - Optional authentication
- Feature flag: `pAllowFingerScan` ("1" = enabled)

**Data Storage:**
- Template stored in `EmplInfo.emplFinger` (type/format unknown)
- Comparison logic in fingerprint SDK (not visible)

⚠️ **SDK Not Documented:** If device or SDK no longer available, fingerprint auth cannot be replicated. Must identify device model from deployments.

### Receipt Printer

**Type:** Likely ESC/POS thermal printer

**Integration Method:** `pPrinterPort` global variable (e.g., "LPT1:", "COM1:", network IP)

**Used By:**
- `PrintAbbBillVat()` in DrugMod.vb - Abbreviated tax bill printing
- Crystal Reports - Full reports (via `pDefaultReportPrinterName`)

**Format:**
- Font: CordiaUPC (Thai Unicode support)
- Sizes: 12pt normal, 10pt small, 8pt tiny
- No graphics; text-only layout
- Multiple payment method columns
- Loyalty points display (HUG Club special handling)

### Barcode Scanner

**Integration:** Keyboard wedge (scanned barcodes appear as typed text)

**Format:** EAN-13 or custom barcode format (not validated in code)

**Trigger:** `txtBarcode.KeyPress` event fires on barcode scan completion

⚠️ **No Validation:** Barcode format not verified; any text scanned is treated as product code.

---

## Display / Screen

### Screen Ratio

**Configuration:** `pScreenRatio` global ("4:3", likely others)

**Usage:** Determines layout adjustments (e.g., hiding picture panel on 4:3 screens)

### Thai Localization

**Language:** All user-facing text in Thai (ไทย)

**Strings Not Centralized:** Hardcoded throughout .vb files (not resource file)

**Examples:**
- "ผู้ใช้ไม่มีสิทธิ์ใช้งานโปรแกรม" (No permission)
- "Username/password ไม่ถูกต้อง" (Incorrect credentials)
- "คะแนนพิเศษสำหรับสมาชิก" (Bonus points for member)

**Character Encoding:** Thai Unicode (TH in code page 874 or UTF-8, depending on file encoding)

**Date Format:** Thai calendar (Gregorian year + 543 for Buddhist calendar display)

### Font Support

**Thai Fonts Used:**
- Tahoma (system font, Thai support in Thai Windows)
- CordiaUPC (printer font, explicitly for Thai receipts)

---

## Licensing & Activation

### Mechanism

**Method:** Hardware serial number or disk identifier (presumed from registry access)

**Registry Key:** `pRegistry` global variable (path unknown from visible code)

**Activation:**
- License check on startup (presumed)
- Per-terminal licensing (assuming one license per POS machine)

**Hardcoded Identifier:** `pProgCode = "PHFR"` (program code)

⚠️ **Registry-Dependent:** Linux/Mac deployments would fail; Windows-only.

---

## Configuration Parameters (Loaded at Startup)

### Company

From BranchInfo or CompanyInfo table (presumed):
- `pCompName`, `pCompName1` - Company name
- `pCompAddress`, `pCompAddr1`, `pCompAddr2` - Address
- `pCompFullName` - Legal name
- `pCompTaxNumber` - Tax ID for invoicing
- `pHugName`, `pHugTaxNumber` - Head office / parent company

### Branch

From BranchInfo table:
- `pBranchCode` - 2-4 digit branch identifier
- `pBranchName` - Display name
- `pBranchAddress` - Physical location
- `pBranchPhone` - Contact number
- `pBranchPrice` - Pricing tier ("1"-"6")
- `pBranchTypeCode` - Type classification
- `pPOSNo`, `pPOSNumber` - POS device identifiers
- `pTaxBranchNo` - Tax branch number (for tax invoicing)
- `pIsFranchise` - Flag: franchise location?

### Business Rules

- `pVat` - VAT rate (%)
- `pBirthPointPlus` - Birthday point multiplier (integer)
- `pBahtPerPoint` - Points conversion (1 point per X baht)
- `pWholeBahtPerPoint` - Wholesale conversion (lower earning)
- `pEmplBuyLimit` - Employee purchase limit (baht)
- `pPerPrice1ToPrice0` - Price tier adjustment percentage

### Feature Flags

- `pAllowWholePrice` - ("1" = show wholesale pricing)
- `pAllowOnlinePrice` - ("1" = enable online sales)
- `pAllowO2OSale` - ("1" = online-to-offline)
- `pAllowTaxInvoice` - ("1" = tax invoice option)
- `pAllowDisc` - ("1" = allow discounts)
- `pAllowDiscEnter` - ("1" = operator can enter custom discount)
- `pAllowFingerScan` - ("1" = use fingerprint auth)
- `pAllowCheckCostAndPrice` - ("1" = audit cost vs margin)
- `pAllowBuyExchange` - ("1" = loyalty exchange vouchers)
- `pAllowEmplPro` - ("1" = employee promotions)
- `pAllowOnlyMembPrice` - ("1" = restrict member price visibility)

### Inventory Management

- `pIsBranchShipTo` - Branch accepts shipments
- `pPricePerOneBuyExchange` - Voucher pricing rule
- `pDayUseBuyExchange` - Voucher validity (days)
- `pShiptoPOLifespan` - PO validity (days)

### Naming & Sequencing

- `pPreSaleNumb` - Prefix for sale document numbers
- `pPreReturnNumb` - Prefix for returns
- `pPreTaxInvoiceNumb` - Prefix for tax invoices

### Pricing Tiers

- `pWholePriceLevel` - Which price tier is wholesale
- `pOnlinePriceLevel` - Which tier is online

### Membership

- `pMembPrice` - Member discount rate (double)
- `pMembExtraPoint` - Extra points for members

### Synchronization

- `pAutoUploadSale` - Auto-sync on transaction complete
- `pOffLineFolder` - Offline data directory

### UI/Display

- `pScreenRatio` - Resolution ratio
- `pPrinterPort` - Receipt printer port
- `pDefaultReportPrinterName` - Crystal Reports printer
- `pBillPrint` - Receipt formatting flag

---

## Performance Assumptions

### Typical Scale

- **Terminals per branch:** 3-5
- **Active branches:** ~100
- **Daily transactions:** ~8,000
- **Peak load:** ~2 requests/sec
- **Response time:** <2 sec expected (based on UI waits)

### Concurrent Access

- **Row Locking:** None (Access limitation; last-write-wins)
- **Transaction Batching:** `UpdateData()` batches 300+ SQL statements
- **Connection Pool:** Not visible; presumed new connection per operation
- **Offline Fallback:** Automatic if server unavailable

---

## Error Handling

### Standard Pattern

All SOAP calls return String array:
- `(0)` = "1" (success), "0" (not found), "-1" (error)
- `(1)` = data or error message
- `(2+)` = additional columns

### Network Failures

- If server unreachable: Caught exception returns "-1"
- Form catches and displays message box
- Operation may be retried or queued to offline

### Data Validation

- No validation layer visible
- Constraints presumed enforced in Access database
- Client-side checks sparse (e.g., barcode format not validated)

---

## Security Landscape

### Authentication

- Username/password stored as plaintext in database
- SQL injection vulnerable at every auth point
- No password strength requirements visible

### Authorization

- String-based privilege codes (case-insensitive comparison)
- Silent failures on permission denial
- Admin (code "5") unaudited

### Audit Trail

- `LogRecord` table captures logins (non-admin only)
- No record of operations, modifications, voids
- `FrontCard` tracks stock movements in detail

### Data Privacy

- No encryption in transit (HTTP SOAP)
- No encryption at rest (Access .mdb plaintext)
- Customer PII stored directly (addresses, birth dates, allergies)

### Compliance

- Thai Pharmacy Regulation presumed (VAT, tax invoicing)
- Drug allergies tracked for patient safety
- PII handling not GDPR-compliant (data stored locally, no explicit consent mechanism visible)

---

## Deployment Model

### Per-Terminal Deployment

- Single Windows executable + config
- Compiled with SOAP endpoints hardcoded
- Local Access database for offline cache
- Registry keys for licensing

### Branch-Level Deployment

- Shared server database (not visible in code; must be separate SQL Server instance)
- Time synchronization via `pService.ServerDateTime`
- Central SOAP service endpoints

### Central Deployment

- Centralized SOAP service (`203.151.212.20`, `110.170.201.18`)
- Master Access database (or SQL Server backend to SOAP)
- Branch configuration in database

⚠️ **No deployment documentation visible;** inferred from code patterns.

---

## Assumptions Made

1. **Server-side:** Central SQL Server or Access database running SOAP web services
2. **Network:** Reliable TCP/IP network within pharmacy chain; Internet for remote branches
3. **Client OS:** Windows XP SP3+ (32-bit or 64-bit with 32-bit Office drivers)
4. **Time Sync:** Network time synchronized within 1-2 minutes (for transaction dating)
5. **Printer:** Thermal receipt printer always available and configured
6. **Barcode Scanner:** USB or keyboard-wedge barcode scanner
7. **Fingerprint Device:** One specific model (unknown) installed and drivers available
8. **User Training:** Operators trained on pharmacy domain (POS terminology, drug names, etc.)

---

## v2 Migration Targets

### Environment Variables for v2

```
DRUGPOS_SERVER_URL=http://api.drugpos-backend/
DRUGPOS_BRANCH_CODE=01
DRUGPOS_POS_NUMBER=POS001
DRUGPOS_OFFLINE_PATH=/local/drugpos_data/
DRUGPOS_PRINTER_PORT=LPT1
DRUGPOS_FINGERPRINT_SDK=path/to/sdk.dll  (if needed)
```

### Configuration File (tauri.conf.json)

```json
{
  "app": {
    "serverUrl": "http://localhost:3000",
    "branch": "01",
    "features": {
      "fingerprint": true,
      "taxInvoice": true,
      "wholesale": true
    }
  },
  "printer": {
    "port": "LPT1",
    "defaultReportPrinter": "Zebra Printer"
  }
}
```

### Database Schema (SQLite v2)

All EAV columns flattened to normalized tables:
```sql
-- In v2:
CREATE TABLE product_prices (
  goodCode TEXT,
  branchCode TEXT,
  tier INTEGER,
  priceAmount DECIMAL
);

-- Instead of:
-- GoodInfo.price1, .price2, ... .price6 columns
-- GoodInfo.stockOnhand01, .stockOnhand02, ... columns
```

