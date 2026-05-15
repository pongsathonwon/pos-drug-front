import { lazy, Suspense } from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import { CircularProgress, Box } from "@mui/material";
import { useSessionStore } from "@store/session";

const LoginPage = lazy(() => import("@features/auth/LoginPage"));
const SalesPage = lazy(() => import("@features/sales/SalesPage"));
const InventoryPage = lazy(() => import("@features/inventory/InventoryPage"));
const LoyaltyPage = lazy(() => import("@features/loyalty/LoyaltyPage"));
const PromotionsPage = lazy(() => import("@features/promotions/PromotionsPage"));
const AccountingPage = lazy(() => import("@features/accounting/AccountingPage"));
const ReportsPage = lazy(() => import("@features/reports/ReportsPage"));

function LoadingFallback() {
  return (
    <Box sx={{ display: "flex", justifyContent: "center", alignItems: "center", height: "100vh" }}>
      <CircularProgress />
    </Box>
  );
}

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const isAuthenticated = useSessionStore((s) => s.isAuthenticated);
  if (!isAuthenticated) return <Navigate to="/login" replace />;
  return <>{children}</>;
}

export default function App() {
  return (
    <Suspense fallback={<LoadingFallback />}>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/sales" element={<ProtectedRoute><SalesPage /></ProtectedRoute>} />
        <Route path="/inventory" element={<ProtectedRoute><InventoryPage /></ProtectedRoute>} />
        <Route path="/loyalty" element={<ProtectedRoute><LoyaltyPage /></ProtectedRoute>} />
        <Route path="/promotions" element={<ProtectedRoute><PromotionsPage /></ProtectedRoute>} />
        <Route path="/accounting" element={<ProtectedRoute><AccountingPage /></ProtectedRoute>} />
        <Route path="/reports" element={<ProtectedRoute><ReportsPage /></ProtectedRoute>} />
        <Route path="/" element={<Navigate to="/sales" replace />} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Suspense>
  );
}
