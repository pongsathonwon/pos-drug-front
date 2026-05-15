import { tauriInvoke, Commands } from "./index";

export interface LoginInput {
  userName: string;
  userPwd: string;
}

export interface LoginResponse {
  emplCode: string;
  emplName: string;
  emplId: string;
  privCode: string;
  emplPosiName: string;
  logSession: string;
}

export interface QuickAuthResponse {
  emplCode: string;
  emplName: string;
  privCode: string;
}

export function login(input: LoginInput): Promise<LoginResponse> {
  return tauriInvoke<LoginResponse>(Commands.LOGIN, { input });
}

export function quickAuth(input: LoginInput): Promise<QuickAuthResponse> {
  return tauriInvoke<QuickAuthResponse>(Commands.QUICK_AUTH, { input });
}

export function changePassword(
  currentPassword: string,
  newUsername: string,
  newPassword: string
): Promise<void> {
  return tauriInvoke<void>(Commands.CHANGE_PASSWORD, {
    currentPassword,
    newUsername,
    newPassword,
  });
}
