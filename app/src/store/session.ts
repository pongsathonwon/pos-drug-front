import { create } from "zustand";
import { persist, createJSONStorage } from "zustand/middleware";

/**
 * Session store — replaces DrugMod.vb public module globals.
 *
 * Legacy mapping:
 *   pUserCode      → userCode
 *   pUserName      → userName
 *   pUserID        → userId
 *   pUserPriv      → userPriv  (e.g. "PHFRA" — concatenated privilege codes)
 *   pUserPosition  → userPosition
 *   pBranchCode    → branchCode
 *   pServerAddr    → serverAddr
 *   pLogSession    → logSession
 *   pLogIn         → isAuthenticated
 */
interface SessionState {
  userCode: string;
  userName: string;
  userId: string;
  userPriv: string;
  userPosition: string;
  branchCode: string;
  serverAddr: string;
  logSession: string;
  isAuthenticated: boolean;

  setSession: (
    session: Omit<
      SessionState,
      "isAuthenticated" | "setSession" | "clearSession" | "hasPrivilege"
    >
  ) => void;
  clearSession: () => void;
  /**
   * Replicates VB: InStr(pUserPriv, privCode) > 0 (case-insensitive).
   * Usage: hasPrivilege("PHFRA") — true if user has Add privilege.
   */
  hasPrivilege: (privCode: string) => boolean;
}

const initialState = {
  userCode: "",
  userName: "",
  userId: "",
  userPriv: "",
  userPosition: "",
  branchCode: "",
  serverAddr: "",
  logSession: "",
  isAuthenticated: false,
};

export const useSessionStore = create<SessionState>()(
  persist(
    (set, get) => ({
      ...initialState,

      setSession: (session) => set({ ...session, isAuthenticated: true }),

      clearSession: () => set({ ...initialState }),

      hasPrivilege: (privCode: string) =>
        get().userPriv.toLowerCase().includes(privCode.toLowerCase()),
    }),
    {
      name: "drugfront-session",
      storage: createJSONStorage(() => sessionStorage),
      partialize: (state) => ({
        userCode: state.userCode,
        userName: state.userName,
        branchCode: state.branchCode,
        isAuthenticated: state.isAuthenticated,
      }),
    }
  )
);
