import { Navigate, Outlet } from "react-router-dom";
import AuthService from "../services/AuthService";


const ProtectedRoute = ({ redirectPath = '/' }) => {
  if (AuthService.isLoggedIn()) {
    return <Outlet />
  }
  return <Navigate to={redirectPath} replace />
};

export default ProtectedRoute;