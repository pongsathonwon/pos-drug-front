use serde::{Deserialize, Serialize};
use thiserror::Error;

/// Typed error enum serialized as a discriminated union to TypeScript.
/// #[serde(tag = "kind", content = "message")] produces: {"kind":"AuthError","message":"..."}
///
/// TypeScript mirror: src/types/errors.ts — keep the two files in sync.
#[derive(Debug, Error, Serialize, Deserialize)]
#[serde(tag = "kind", content = "message")]
pub enum AppError {
    #[error("Authentication failed: {0}")]
    AuthError(String),

    #[error("Forbidden: insufficient privileges")]
    Forbidden,

    #[error("Not found: {0}")]
    NotFound(String),

    #[error("Database error: {0}")]
    DatabaseError(String),

    #[error("Validation error: {0}")]
    ValidationError(String),

    #[error("Sync error: {0}")]
    SyncError(String),

    #[error("Hardware error: {0}")]
    HardwareError(String),

    #[error("Internal error: {0}")]
    InternalError(String),
}

impl From<sqlx::Error> for AppError {
    fn from(e: sqlx::Error) -> Self {
        match e {
            sqlx::Error::RowNotFound => AppError::NotFound("Record not found".to_string()),
            other => AppError::DatabaseError(other.to_string()),
        }
    }
}

impl From<bcrypt::BcryptError> for AppError {
    fn from(e: bcrypt::BcryptError) -> Self {
        AppError::InternalError(format!("Bcrypt error: {e}"))
    }
}
