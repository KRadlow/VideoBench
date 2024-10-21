import { Navigate, Outlet } from "react-router-dom";
import AuthService from "../services/AuthService";


const ProtectedRoute = ({ redirectPath = '/' }) => {
  if (AuthService.isAuthenticated()) {
    return <Outlet />
  }
  return <Navigate to={redirectPath} replace />
};

export default ProtectedRoute;