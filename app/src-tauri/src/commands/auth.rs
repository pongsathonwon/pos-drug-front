use crate::AppError;
use serde::{Deserialize, Serialize};

/// Mirrors frmLogIn.vb session variables (DrugMod.vb globals).
/// Fields use camelCase to match TypeScript LoginResponse in src/api/auth.ts.
#[derive(Debug, Serialize, Deserialize)]
#[serde(rename_all = "camelCase")]
pub struct LoginResponse {
    pub empl_code: String,
    pub empl_name: String,
    pub empl_id: String,
    pub priv_code: String,
    pub empl_posi_name: String,
    pub log_session: String,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
#[allow(dead_code)]
pub struct LoginInput {
    pub user_name: String,
    pub user_pwd: String,
}

/// Replaces: pService.GetData("Drug", "SELECT ... FROM EmplInfo WHERE userName=? AND userPWD=?")
/// Legacy ref: frmLogIn.vb:184
///
/// CRITICAL: VB string comparison is case-insensitive — use LOWER() in SQL.
/// CRITICAL: Privilege check InStr(privCode, "PHFR") must be case-insensitive.
/// CRITICAL: Never retry this command on failure — double-login is not safe.
#[tauri::command]
pub async fn login(input: LoginInput) -> Result<LoginResponse, AppError> {
    // TODO: implement with sqlx query after schema is finalized (Session 2)
    // Query pattern (parameterized only — never string-concatenate SQL):
    //
    // SELECT EI.emplCode, EI.emplName, EI.emplID, EI.privCode, EP.emplPosiName
    // FROM EmplInfo EI
    // INNER JOIN EmplPosition EP ON EP.emplPosiCode = EI.emplPosiCode
    // WHERE EI.emplStat = '1'
    //   AND LOWER(EI.userName) = LOWER($1)
    // Then bcrypt::verify(input.user_pwd, stored_hash)
    //
    // Privilege gate: if !priv_code.to_lowercase().contains("phfr") { return Err(Forbidden) }

    let _ = input;
    Err(AppError::InternalError("login not yet implemented".to_string()))
}

#[derive(Debug, Serialize, Deserialize)]
#[serde(rename_all = "camelCase")]
pub struct QuickAuthResponse {
    pub empl_code: String,
    pub empl_name: String,
    pub priv_code: String,
}

/// Simpler than login — no position lookup, no LogRecord insert, no session token.
/// Legacy ref: frmPass.vb:23
#[tauri::command]
pub async fn quick_auth(input: LoginInput) -> Result<QuickAuthResponse, AppError> {
    let _ = input;
    Err(AppError::InternalError("quick_auth not yet implemented".to_string()))
}

/// Legacy ref: frmChangePassword.vb
#[tauri::command]
pub async fn change_password(
    current_password: String,
    new_username: String,
    new_password: String,
) -> Result<(), AppError> {
    let _ = (current_password, new_username, new_password);
    Err(AppError::InternalError("change_password not yet implemented".to_string()))
}
