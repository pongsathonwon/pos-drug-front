/**
 * Mirror of src-tauri/src/error.rs AppError enum.
 * Rust #[serde(tag="kind", content="message")] produces this exact shape.
 *
 * KEEP IN SYNC: any new AppError variant in Rust must be added here.
 */
export type AppError =
  | { kind: "AuthError"; message: string }
  | { kind: "Forbidden"; message: string }
  | { kind: "NotFound"; message: string }
  | { kind: "DatabaseError"; message: string }
  | { kind: "ValidationError"; message: string }
  | { kind: "SyncError"; message: string }
  | { kind: "HardwareError"; message: string }
  | { kind: "InternalError"; message: string };

export function isAppError(value: unknown): value is AppError {
  return (
    typeof value === "object" &&
    value !== null &&
    "kind" in value &&
    typeof (value as Record<string, unknown>).kind === "string"
  );
}

export function getThaiErrorMessage(error: AppError): string {
  switch (error.kind) {
    case "AuthError":
      return "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
    case "Forbidden":
      return "ผู้ใช้ไม่มีสิทธิ์ใช้งานโปรแกรม";
    case "NotFound":
      return `ไม่พบข้อมูล: ${error.message}`;
    case "DatabaseError":
      return "เกิดข้อผิดพลาดในฐานข้อมูล กรุณาติดต่อผู้ดูแลระบบ";
    case "ValidationError":
      return `ข้อมูลไม่ถูกต้อง: ${error.message}`;
    case "SyncError":
      return `ไม่สามารถซิงค์ข้อมูลได้: ${error.message}`;
    case "HardwareError":
      return `ข้อผิดพลาดฮาร์ดแวร์: ${error.message}`;
    case "InternalError":
      return "เกิดข้อผิดพลาดภายในระบบ กรุณาติดต่อผู้ดูแลระบบ";
  }
}
