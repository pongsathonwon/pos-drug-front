use sqlx::{sqlite::SqlitePoolOptions, SqlitePool};
use std::fs;
use tauri::{AppHandle, Manager};

pub async fn initialize(app: &AppHandle) -> Result<SqlitePool, crate::AppError> {
    let app_dir = app
        .path()
        .app_data_dir()
        .map_err(|e| crate::AppError::InternalError(e.to_string()))?;

    fs::create_dir_all(&app_dir)
        .map_err(|e| crate::AppError::InternalError(e.to_string()))?;

    let db_path = app_dir.join("drugfront.db");
    let db_url = format!("sqlite://{}?mode=rwc", db_path.display());

    let pool = SqlitePoolOptions::new()
        .max_connections(5)
        .connect(&db_url)
        .await
        .map_err(crate::AppError::from)?;

    sqlx::migrate!("./src/db/migrations")
        .run(&pool)
        .await
        .map_err(|e| crate::AppError::InternalError(e.to_string()))?;

    app.manage(pool.clone());

    Ok(pool)
}
