#[allow(unused_imports)]
use tauri::Manager;

mod commands;
mod db;
mod error;

pub use error::AppError;

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    tauri::Builder::default()
        .plugin(tauri_plugin_opener::init())
        .setup(|app| {
            let app_handle = app.handle().clone();
            tauri::async_runtime::spawn(async move {
                if let Err(e) = db::initialize(&app_handle).await {
                    eprintln!("Database initialization failed: {e}");
                }
            });
            Ok(())
        })
        .invoke_handler(tauri::generate_handler![
            commands::auth::login,
            commands::auth::quick_auth,
            commands::auth::change_password,
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
