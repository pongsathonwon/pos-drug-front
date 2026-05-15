import { invoke } from "@tauri-apps/api/core";
import { isAppError, type AppError } from "@/types/errors";

/**
 * Typed Tauri invoke wrapper.
 * Narrows Tauri's thrown error to AppError so callers never receive `unknown`.
 */
export async function tauriInvoke<T>(
  command: string,
  args?: Record<string, unknown>
): Promise<T> {
  try {
    return await invoke<T>(command, args);
  } catch (error) {
    if (isAppError(error)) {
      throw error;
    }
    if (typeof error === "string") {
      throw { kind: "InternalError", message: error } satisfies AppError;
    }
    throw { kind: "InternalError", message: String(error) } satisfies AppError;
  }
}

/** Single source of truth for Tauri command names — prevents typos. */
export const Commands = {
  // Auth
  LOGIN: "login",
  QUICK_AUTH: "quick_auth",
  CHANGE_PASSWORD: "change_password",
  ENROLL_FINGERPRINT: "enroll_fingerprint",
  // Drug / Inventory
  GET_DRUG_BY_BARCODE: "get_drug_by_barcode",
  GET_DRUG_PRICING: "get_drug_pricing",
  GET_STOCK_ONHAND: "get_stock_onhand",
  // Customer
  GET_CUSTOMER: "get_customer",
  GET_CUSTOMER_POINTS: "get_customer_points",
  // Sales
  CHECK_ALLERGY: "check_allergy",
  CREATE_SALE: "create_sale",
  GET_ACTIVE_PROMOTIONS: "get_active_promotions",
  CALCULATE_DISCOUNT: "calculate_discount",
  // Accounting
  GET_CLOSE_SUMMARY: "get_close_summary",
  POST_ACCOUNTING_CLOSE: "post_accounting_close",
  // Sync
  GET_SYNC_STATUS: "get_sync_status",
  UPLOAD_OFFLINE_SALES: "upload_offline_sales",
  // Reports
  GET_STOCK_REPORT: "get_stock_report",
  GET_SALES_REPORT: "get_sales_report",
} as const;
