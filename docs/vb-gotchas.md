# VB.NET Behavioral Traps & Legacy Quirks

## Critical Traps to Reproduce in v2

### 1. Case-Insensitive String Comparison

**VB Behavior:**
```vb
If "Admin" = "admin" Then
  ' TRUE in VB (case-insensitive by default)
End If

If InStr("PHFRA", "phfr") > 0 Then
  ' TRUE - InStr is case-insensitive
End If
```

**TypeScript/Rust Behavior:**
```typescript
if ("Admin" === "admin") {
  // FALSE - case-sensitive
}

if ("PHFRA".includes("phfr")) {
  // FALSE - includes is case-sensitive
}
```

**Impact on Auth:**
- Privilege checking: `InStr(pUserPriv, Me.Tag.ToString & "A")`
- If pUserPriv = "phfra" and code expects "PHFRA", port must use `.toLowerCase()` or `.to_lowercase()`
- **Status:** Code appears to assume uppercase, but no explicit enforcement. Risk: privilege bypass if case mismatch.

**Impact on Code Lookup:**
- pProgCode = "PHFR" (hardcoded)
- Privilege string may contain "PHFRA" or "phfra"; code does not normalize
- **v2 Solution:** Always convert to same case before comparing

---

### 2. 1-Based Array Indexing (VB Collections)

**VB Behavior:**
```vb
Dim arr() As String
ReDim arr(3)  ' Creates indices 0, 1, 2, 3 (4 elements)

' SOAP returns:
Dim mGet() As String
mGet = pService.GetData(...)
mGet(0) = "1"      ' Status code
mGet(1) = column1
mGet(2) = column2
' 1-based indexing for data, 0-based for status!
```

**Risk:**
- If ported as-is, TypeScript/Rust 0-based arrays will be off by one
- Result(0) in VB becomes result[0] in TS, but means DIFFERENT data
- **Solution:** Explicitly remap: TS result[0] = VB result(1), etc.

**Count:**
- 116 instances of `mGet(0) = "1"` pattern across 29 files
- Every single SOAP call needs audit

---

### 3. String-Based Status Codes vs Boolean/Enum

**VB Pattern:**
```vb
If mGet(0) = "1" Then          ' Success
Else If mGet(0) = "0" Then     ' No records
Else If mGet(0) = "-1" Then    ' Error
End If

If emplStat = "1" Then         ' Active
Else                           ' Inactive
End If

If flag = "2" Then             ' Synced
Else If flag = "1" Then        ' Not synced
End If
```

**Fragility:**
- String concatenation everywhere; typos silently fail
- No type safety
- **v2 Solution:** Create Rust enums / TypeScript discriminated unions

---

### 4. Plaintext Password Storage & Comparison

**VB:**
```vb
' In database:
UPDATE EmplInfo SET userPWD = 'password123'

' In auth check:
WHERE EI.userPWD = '" & txtUserPassword.Text & "'
```

**Risk:**
- Trivial to breach if DB accessed
- No hashing, no salt, no bcrypt
- SQL injection + plaintext = catastrophic

**v2 Must:**
- Never store plaintext
- Use bcrypt or Argon2
- Compare hashes only
- Hash passwords at entry point (client-side pre-hash if client-server, or server-side hash)

---

### 5. Date Format Assumptions (Thai Calendar)

**VB Pattern:**
```vb
' Thai year = Gregorian + 543
Function ThaiNumbDate(mDate As Date) As String
  Return mDate.Day.ToString("0#") & "/" & mDate.Month.ToString("0#") & "/" & (mDate.Year + 543).ToString
End Function

' Called in SQL:
"WHERE saleDate = '" & MDYStr(pServerDateTime.Date) & "'"
' Produces: "1/15/2024"  (assumes M/D/YYYY parsing by Access)
```

**Risk:**
- If locale settings on DB server differ, date parsing fails silently
- Thai dates hardcoded; if system switches to Gregorian, all stored dates break
- Mixing formats: some columns store Thai year, others don't

**v2 Must:**
- Standardize on ISO 8601 (YYYY-MM-DD) in database
- Parse dates using explicit locale/format, never implicit
- Handle Thai calendar conversion explicitly at UI layer only

---

### 6. Global Mutable State (DrugMod.vb)

**VB:**
```vb
Public pUserCode As String
Public pBranchCode As String
Public pServerDateTime As Date
' ~100 more public variables

' Any form can modify:
pUserCode = mGet(1)
pBranchCode = "01"
pServerDateTime = pService.ServerDateTime
```

**Risk:**
- No encapsulation; any form can corrupt state
- Concurrent forms may see inconsistent state
- Debugging: unclear who changed what variable
- Testing: cannot isolate state between tests

**v2 Solution:**
- Single immutable Session object created at login
- Passed to all forms/commands, never mutated
- Dependency injection; no global access

---

### 7. Implicit Type Conversion & Numeric Coercion

**VB:**
```vb
Dim mNumber As Integer = CInt("10")   ' Works
Dim mNumber As Integer = CInt("")     ' ERROR: empty string
Dim mNumber As Integer = Val("")      ' Returns 0
Dim mNumber As Integer = CInt("10.5") ' Returns 10 (truncates)

' String concat with numbers:
"Total: " & 123.45  ' Auto-converts to "Total: 123.45"

' Math with mixed types:
Dim result = 10 / 3  ' Integer division? Double division? Depends.
Dim result = 10.0 / 3  ' Clearly double
```

**Risk:**
- Implicit conversions hide bugs
- Division behavior depends on operand types
- Empty strings coerce to 0 in some contexts, error in others

**v2 Must:**
- Explicit type conversion everywhere
- Fail-fast on type mismatch (not silent coercion)

---

### 8. Nothing vs "" vs 0

**VB:**
```vb
If IsNothing(ds) = False Then
  ' ds is not null
End If

If txtName.Text <> "" Then
  ' Not empty string
End If

If CInt(mGet(1)) > 0 Then
  ' Greater than 0
End If

' Checking for "no record":
If mGet(0) = "0" Then  ' No record found
  If mGet(1) <> "" Then  ' Message in result(1)
  End If
End If
```

**Ambiguity:**
- Empty string ("") vs null (Nothing) treated differently
- Code sometimes checks `<> ""`, sometimes checks `IsNothing()`
- Unclear which is used for "no data"

**v2 Must:**
- Distinguish: null (field missing) vs empty string (blank value)
- Option/Result types in Rust; Optional in TypeScript
- Never conflate the two

---

### 9. String SQL Concatenation (SQL Injection)

**VB Pattern:**
```vb
' Every SOAP call looks like:
Dim sql As String = "SELECT ... WHERE goodCode = '" & GoodCode & "'"
mGet = pService.GetData("Drug", sql)

' If GoodCode = "' OR '1'='1", SQL becomes:
' SELECT ... WHERE goodCode = '' OR '1'='1'
```

**Found in:**
- frmLogIn.vb line 184: username/password check
- frmSale.vb line 254: product lookup
- frmUploadServer.vb: dozens of inserts/updates
- **Every SOAP call across 29 files** (116+ instances)

**Risk:**
- Authentication bypass via `' OR '1'='1' --`
- Data exfiltration via UNION SELECT
- Data modification via UPDATE/DELETE
- Loss of entire database

**v2 Must:**
- **ZERO string SQL**
- Always use parameterized queries
- Tauri command parameters passed separately from SQL
- Rust backend uses sqlx or similar with compile-time checked queries

---

### 10. Hardcoded IP Addresses & Credentials

**app.config:**
```xml
<setting name="DrugFront_MyService_Service" serializeAs="String">
  <value>http://203.151.212.20/MyService/Service.asmx</value>
</setting>
<setting name="DrugFront_MyService3_Service" serializeAs="String">
  <value>http://110.170.201.18/MyService3/service.asmx</value>
</setting>
```

**Risk:**
- IP addresses are production endpoints (not configurable)
- HTTP (unencrypted)
- Visible in compiled app.config
- If IP changes, app breaks until recompiled

**v2 Must:**
- No hardcoded IPs
- Configuration from environment variables / tauri.conf.json
- HTTPS only
- Runtime endpoint discovery (optional: DNS round-robin)

---

### 11. Registry Access (License/Hardware ID)

**DrugMod.vb:**
```vb
Public pRegistry As String
' Likely reads hardware serial number or license key
```

**Risk:**
- Registry access requires permissions
- Registry keys may not exist on all machines
- Windows-specific (breaks on Linux)
- No error handling visible

**v2 Must:**
- License validation decoupled from hardware
- Cloud-based license check (optional offline grace period)
- Not registry-dependent

---

### 12. Relative File Paths & Working Directory Assumptions

**DrugMod.vb:**
```vb
' Absolute path:
"Provider=Microsoft.JET.OLEDB.4.0;Data Source=" & pOffLineFolder & "data.mdb"

' Relative path:
"Data Source=data.mdb"

' If working directory is unexpected, both fail silently or access wrong file
```

**Risk:**
- Offline database may be in wrong location if app launched from unexpected directory
- No error message; just fails to connect

**v2 Must:**
- Always use absolute paths
- Never depend on working directory
- Tauri app directory always known (app data folder)

---

### 13. On Error Resume Next (Not Found, But Watch For)

**Pattern Absent in DrugMod, but check all forms:**
```vb
' NOT found in samples, but always check for:
On Error Resume Next
' ... code that might fail silently ...
```

**Finding:** Zero instances found in grep. Good sign.

**v2 Pattern:**
- Never silently swallow errors
- All errors bubble to top-level handler
- User sees clear message or logs error with context

---

### 14. VB Collection Behavior (DataView, DataTable)

**VB:**
```vb
Dim dv As DataView = ds.Tables(0)  ' DataView count
If dv.Count > 0 Then
  Dim row = dv.Item(0)  ' First row (0-indexed)
  mValue = row.Item(0)  ' First column (0-indexed)
End If

' But GetData returns:
Dim mGet() As String
mGet(0) = status
mGet(1) = column1  ' 1-indexed!
```

**Inconsistency:**
- DataView/DataTable use 0-based indexing (standard .NET)
- String array results use 1-based indexing (legacy VB convention)
- Same function, different indexing!

---

### 15. Datetime Arithmetic & Timezone

**VB:**
```vb
Dim pServerDateTime As Date
pServerDateTime = pService.ServerDateTime  ' When is this fetched?

' Compared against local machine date:
If saleDate = pServerDateTime.Date Then
  ' Matching date
End If
```

**Risk:**
- Server timezone unknown
- Client timezone may differ
- Daylight saving time not handled
- If server in Bangkok (+7) and client in Sydney (+10), dates may be off

**v2 Must:**
- Always use UTC server time
- Convert to local display time only at UI
- Store times in UTC, never local

---

### 16. Off-By-One in Loops

**VB:**
```vb
For x = 0 To mLen - 1
  mChar(x + 1) = Mid(mNumb, mLen - x, 1)  ' 1-based array!
Next

' Correct in VB, breaks in 0-based languages
```

**Found:** Line 248-249 in DrugMod.vb (SayNumb function)

**Risk:** When ported to TypeScript/Rust, must adjust loop bounds

---

### 17. String Replace & Case Sensitivity

**VB:**
```vb
MyVal(text) function:
Return Val(Replace(mText, ",", ""))  ' Replace all commas
```

**VB Replace default:** Case-insensitive

**Risk:** If number uses "," as thousands separator (Thai locale), but text has "," from elsewhere, wrong values result.

---

### 18. Null Reference Handling

**VB:**
```vb
If IsNothing(ds) = False Then
  Dim dv As New DataView(ds.Tables(0))
  ' Can crash here if ds.Tables(0) doesn't exist
End If

' Better:
If IsNothing(ds) = False AndAlso ds.Tables.Count > 0 Then
  ' Safe
End If
```

**Found:** Multiple instances; some missing bounds checks.

---

### 19. Currency Rounding (No Banker's Rounding)

**VB:**
```vb
' RoundMoney uses simple tie-breaking
If val >= 0.50 Then roundUp Else roundDown

' Not Banker's Rounding (round-to-even), which is more precise
```

**Audit:** Check accounting close to ensure rounding doesn't accumulate errors

---

## Summary of Critical Porting Issues

| Issue | Severity | Count | Fix |
|-------|----------|-------|-----|
| Case-insensitive comparisons | HIGH | Many | Explicit .toLowerCase() / .to_lowercase() |
| 1-based indexing | HIGH | 116+ | Remap all SOAP calls to 0-based |
| String SQL concatenation | CRITICAL | 116+ | Parameterized queries only |
| Plaintext passwords | CRITICAL | 1 | bcrypt/Argon2 hashing |
| Global mutable state | HIGH | ~100 vars | Scoped immutable Session object |
| Date format assumptions | HIGH | Many | ISO 8601 + explicit locale handling |
| Hardcoded IPs | MEDIUM | 2 | Environment configuration |
| Relative file paths | MEDIUM | 2+ | Absolute paths always |
| Registry access | MEDIUM | 1+ | Cloud licensing / app config |
| Implicit type coercion | MEDIUM | Many | Explicit conversions |

