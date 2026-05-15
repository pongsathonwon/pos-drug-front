import { createTheme } from "@mui/material/styles";
import { thTH } from "@mui/material/locale";
import "@fontsource/sarabun/300.css";
import "@fontsource/sarabun/400.css";
import "@fontsource/sarabun/500.css";
import "@fontsource/sarabun/700.css";

const thaiFont = ["Sarabun", "Tahoma", "sans-serif"].join(",");

const baseComponents = {
  MuiButton: {
    styleOverrides: {
      root: {
        textTransform: "none" as const, // Thai text must never be uppercased
        fontFamily: thaiFont,
      },
    },
  },
  MuiTextField: {
    defaultProps: { size: "small" as const },
  },
  MuiTableCell: {
    styleOverrides: {
      root: { fontFamily: thaiFont, fontSize: "0.875rem" },
    },
  },
};

const baseTypography = {
  fontFamily: thaiFont,
  fontSize: 14,
};

export const lightTheme = createTheme(
  {
    typography: baseTypography,
    shape: { borderRadius: 4 },
    components: baseComponents,
    palette: {
      mode: "light",
      primary: { main: "#1565c0", light: "#5e92f3", dark: "#003c8f" },
      secondary: { main: "#2e7d32", light: "#60ad5e", dark: "#005005" },
      error: { main: "#c62828" },
      warning: { main: "#f57f17" },
      background: { default: "#f5f5f5", paper: "#ffffff" },
    },
  },
  thTH
);

export const darkTheme = createTheme(
  {
    typography: baseTypography,
    shape: { borderRadius: 4 },
    components: baseComponents,
    palette: {
      mode: "dark",
      primary: { main: "#5e92f3", light: "#90c3ff", dark: "#1565c0" },
      secondary: { main: "#60ad5e", light: "#90df8e", dark: "#2e7d32" },
      error: { main: "#ef5350" },
      background: { default: "#121212", paper: "#1e1e1e" },
    },
  },
  thTH
);

export type ThemeMode = "light" | "dark";
