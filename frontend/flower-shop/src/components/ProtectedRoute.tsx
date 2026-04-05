import { Navigate } from "react-router-dom";
import { useAuthStore } from "../store/authStore";
import { parseJwt } from "../utils/auth";

export default function ProtectedRoute({ children, role }: any) {
  const token = useAuthStore((s) => s.token);

  if (!token) return <Navigate to="/login" />;

  const user = parseJwt(token);
  
  if (role && user.role !== role)
    return <Navigate to="/" />;

  return children;
}