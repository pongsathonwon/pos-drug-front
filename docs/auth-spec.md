# Auth Specification

## Login Flow (frmLogIn.vb)

### Step 1: User Input

- Operator enters `userName` and `userPWD` in frmLogIn
- Both fields are required (length > 0 check)

### Step 2: Authentication Query

```sql
SELECT EI.emplCode,
       EI.emplName,
       EI.emplID,
       EI.privCode,
       EP.emplPosiName
FROM EmplInfo EI
INNER JOIN EmplPosition EP
  ON EP.emplPosiCode = EI.emplPosiCode
WHERE EI.emplStat = '1'
  AND EI.userName = '[txtUserName.Text]'
  AND EI.userPWD = '[txtUserPassword.Text]'
```

**Call:** `pService.GetData("Drug", sqlQuery)` (line 184)

**Result Array:**

- Index 0: "1" = success, "0" = no record, "-1" = error
- Index 1: emplCode (employee ID)
- Index 2: emplName (full name with possible nickname in parentheses)
- Index 3: emplID (alternate ID)
- Index 4: privCode (privilege/role code string)
- Index 5: emplPosiName (position title)

### Step 3: Authorization Check

```vb
If mGet(0) = "1" Then
  If InStr(mGet(4), pProgCode) = 0 Then
    ' Permission denied: user doesn't have PHFR program access
    MessageBox.Show("ผู้ใช้ไม่มีสิทธิ์ใช้งานโปรแกรม")
  Else
    ' Permission granted: proceed with session setup
```

- `pProgCode = "PHFR"` (global constant)
- `mGet(4)` contains comma-separated or concatenated privilege codes
- VB InStr is **case-insensitive** by default: "PHFR" matches "phfr"
- If "PHFR" not found in privilege string → deny access

### Step 4: Session Variables Assignment

```vb
pUserCode = mGet(1)        ' emplCode
pUserName = RemoveNickName(mGet(2))  ' emplName without (nickname)
pUserID = mGet(3)          ' emplID
pUserPriv = mGet(4)        ' privCode string (e.g., "PHFRA")
pUserPosition = mGet(5)    ' emplPosiName
pLogIn = True
```

**pUserName Processing:**

- Function `RemoveNickName()` removes parentheses and content: "John (Johnny) Doe" → "John Doe"

### Step 5: Login Timestamp (Non-Admin Only)

```vb
If pUserCode <> "5" Then
  pServerDateTime = pService.ServerDateTime
  pLogSession = pBranchCode & pUserCode & Format(pServerDateTime, "ddMMyyHHmmss")

  ' Log the login event
  mSqlText(0) = "INSERT INTO LogRecord
                  (branchCode, logSession, logInDate, logInTime, emplCode, drugFrontVersion)
                VALUES ('" & pBranchCode & "', '" & pLogSession & "',
                        '" & MDYStr(pServerDateTime.Date) & "',
                        '" & Format(pServerDateTime, "HH:mm") & "',
                        '" & pUserCode & "',
                        '" & Application.ProductVersion & "')"
  mUpdate = pService.UpdateData("Drug", mSqlText)
End If
```

- **Admin (emplCode = "5")** is NOT logged - skips LogRecord insertion
- LogRecord captures: branch, session ID, date, time, employee, app version
- pLogSession format: BranchCode(4) + UserCode(2+) + Timestamp(12) = ~18+ characters

### Step 6: Form Close

```vb
Me.Close()
```

Dialog closes; calling form (frmMain) checks `pLogIn` flag and continues initialization.

---

## Fingerprint Authentication (frmFingerPrintEnroll.vb)

### Overview

Fingerprint reader integration for enrollment and verification. Device details not documented in code.

### Enrollment Process

```vb
' Enroll new fingerprint
mGet = pService.GetData("Drug",
  "SELECT emplCode, emplName FROM EmplInfo WHERE emplCode = '[code]'")
If mGet(0) = "1" Then
  ' Capture fingerprint from device
  ' Store template in EmplInfo.emplFinger (presumed column)
  ' Update EmplInfo SET emplFinger = '[template_data]'
End If
```

⚠️ Code snippet limited in available documentation; full enrollment logic not fully visible.

### Verification

- Called from login or access control
- Compares captured fingerprint against enrolled template
- Result feeds into permission system

---

## Password Storage & Comparison

### Storage Format

⚠️ **CRITICAL VULNERABILITY**: Passwords are stored in plaintext in EmplInfo.userPWD column.

```sql
-- Password stored as-is in database
UPDATE EmplInfo SET userPWD = 'password123' WHERE emplCode = '001'

-- Compared directly in WHERE clause
SELECT * FROM EmplInfo
WHERE userName = 'john' AND userPWD = 'password123'
```

### Change Password (frmChangePassword.vb)

```vb
' Get current user's credentials
mGet = pService.GetData("Drug",
  "Select userName, userPWD From EmplInfo Where emplCode = '" & pUserCode & "'")

' Check new username is unique
mGet = pService.GetData("Drug",
  "Select emplCode From EmplInfo Where userName = '" & txtNewName.Text &
  "' And emplCode <> '" & pUserCode & "'")

If mGet(0) = "1" Then
  ' Duplicate username - error
Else
  ' Update both username and password
  mSqlText(0) = "Update EmplInfo set userName = '" & txtNewName.Text &
    "', userPWD = '" & txtNewPassword.Text &
    "' Where emplCode = '" & pUserCode & "'"
  mUpdate = pService.UpdateData("Drug", mSqlText)
End If
```

⚠️ Both username and password updated as plaintext strings.

---

## Permission / Role System

### Architecture

**String-based privilege codes** stored in EmplInfo.privCode column.

Example format: `"PHFRA"` where:

- `PHFR` = program code (DrugFront)
- `A` = likely "Add" permission
- Other codes: `P` (Print?), other letters

### Permission Checking Pattern

From frmSale.vb line 202:

```vb
If InStr(pUserPriv, Me.Tag.ToString & "A") <= 0 Then
  Exit Sub  ' No permission - silently exit
End If
```

- `pUserPriv` = privilege string (e.g., "PHFRA")
- `Me.Tag` = form's internal code (e.g., "PHFR")
- `Me.Tag & "A"` = required privilege (e.g., "PHFRA")
- `InStr(...) <= 0` = privilege NOT found → deny

⚠️ **Silent Failure**: If permission denied, function simply exits without error message. UI may appear to hang or be unresponsive.

### Privilege Combinations

- `PHFRA` = Add permission
- `PHFRP` = Print permission
- Possibly: `PHFRE` = Edit, `PHFRD` = Delete, `PHFRV` = View

Actual list stored in database, not hardcoded; must audit all permission checks.

---

## Logout / Session Termination

### Implicit Logout

No explicit logout function found. Closing main form (`frmMain`) effectively logs out by:

1. Clearing `pUserCode`, `pUserName`, etc. (not explicitly done in code)
2. Closing all open forms
3. Returning to login screen

### Session Cleanup

No session invalidation on server. If user logs in again while session is still "active" on server, both sessions remain valid.

---

## Admin Account Special Handling

### Hardcoded Admin Check

```vb
If pUserCode <> "5" Then
  ' Non-admin: log the login event
Else
  ' Admin: skip logging
End If
```

Employee with emplCode = "5" is treated as admin:

- Bypasses LogRecord insertion
- No audit trail for admin logins
- Presumed to have all permissions (code does not verify)

---

## Login Errors

| Condition                        | Message                          | Code                |
| -------------------------------- | -------------------------------- | ------------------- |
| Empty username or password       | N/A (button disabled)            | Line 180 validation |
| User not found / wrong password  | "Username/password ไม่ถูกต้อง"   | Line 217-227        |
| User found but no PHFR privilege | "ผู้ใช้ไม่มีสิทธิ์ใช้งานโปรแกรม" | Line 188-189        |
| LogRecord insert fails           | "Cannot insert login time"       | Line 208            |

---

## Related Authentication Forms

### frmPass.vb (Quick Login / Auth Check)

```vb
mGet = pService.GetData("Drug",
  "SELECT emplCode, emplName, privCode
   FROM EmplInfo
   WHERE emplStat = '1'
   AND userName = '" & txtUserName.Text & "'
   AND userPWD = '" & txtUserPassword.Text & "'")
```

Simpler than frmLogIn (no position lookup). Used for mid-session authentication checks.

### frmChangePassword.vb (Password Change)

- Allows current user to change their userName and userPWD
- Updates both fields simultaneously
- Checks for duplicate username before updating
- No password strength validation

---

## ⚠️ Security Risks Summary

1. **Plaintext Passwords**: All passwords stored and compared in plaintext. Immediate vulnerability.
2. **SQL Injection**: Every auth query built via string concatenation. Usernames/passwords containing quotes bypass auth.
3. **No Session Token**: Session ID (`pLogSession`) is not cryptographically secure; format is deterministic (timestamp).
4. **Admin Bypass**: Admin (code "5") not logged; admin login unauditable.
5. **Silent Failures**: Permission denials exit silently; operator may not know access was denied.
6. **Case-Insensitive Privilege Check**: VB InStr default behavior may allow privilege bypass if case depends on upstream logic.
7. **Global Session State**: All auth data in public module variables; any form can read/modify.
8. **No Logout**: Session never explicitly invalidated; concurrent logins possible.
9. **Hardcoded Program Code**: "PHFR" hardcoded; privilege system depends on exact string match (fragile).
