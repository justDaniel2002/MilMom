import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";

import MainLayout from "./layouts/mainLayout";
import ProductDetail from "./pages/ProductDetail";
import Cart from "./pages/Cart";
import Home from "./pages/Home";
import AuthLayout from "./layouts/authLayout";
import Login from "./pages/Auth/Login";
import Register from "./pages/Auth/Register";
import ForgotPassword from "./pages/Auth/ForgotPassword";
import UnvalidEmail from "./pages/Auth/UnvalidEmail";
import ValidEmail from "./pages/Auth/ValidEmail";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { RecoilRoot, useRecoilState } from "recoil";
import ProtectedLayout from "./layouts/protectedLayout";
import ProtectedAuthLayout from "./layouts/protectedAuthLayout";
import { provinesAtom } from "./atom/provinesAtom";
import { useEffect } from "react";
import axios from "axios";
import PaymentSuccessful from "./pages/PaymentSuccessful";
import AdminLayout from "./layouts/adminLayout";
import Dashboard from "./pages/Admin/Dashboard";
import UserManager from "./pages/Admin/UserManager";
import StaffLayout from "./layouts/staffLayout";
import ReportManager from "./pages/Staff/ReportManager";
import OrderManager from "./pages/Staff/OrderManager";
import RevenueManager from "./pages/Admin/RevenueManager";
import StatisticalProduct from "./pages/Admin/StatisticalProduct";
import ManagerLayout from "./layouts/managerLayout";
import ProductManager from "./pages/Manager/ProductManager";
import CreateProduct from "./pages/Manager/CreateProduct";
import ProfileLayout from "./layouts/profileLayout";
import Profile from "./pages/Profile";
import ProfileEdit from "./pages/ProfileEdit";
import ChangePassword from "./pages/ChangePassword";
import ProfileOrder from "./pages/ProfileOrder";
function App() {
  const [provines, setProvines] = useRecoilState(provinesAtom);

  useEffect(() => {
    axios
      .get("https://esgoo.net/api-tinhthanh/4/0.htm")
      .then((result) => setProvines(result.data.data));
  }, []);
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route element={<AuthLayout />}>
          <Route path="login" element={<Login />} />
        </Route>

        <Route element={<AuthLayout width="w-1/3" />}>
          <Route path="register" element={<Register />} />
        </Route>

        <Route element={<ProtectedAuthLayout />}>
          <Route path="forgotPassword" element={<ForgotPassword />} />

          <Route path="unvalidEmail" element={<UnvalidEmail />} />

          <Route path="validEmail" element={<ValidEmail />} />
        </Route>

        <Route path="/" element={<MainLayout />}>
          <Route index element={<Home />} />
          <Route path="productDetail/:id" element={<ProductDetail />} />

          <Route element={<ProtectedLayout />}>
            <Route path="cart" element={<Cart />} />
            <Route path="profile" element={<ProfileLayout />}>
              <Route index element={<Profile />} />
              <Route path="editProfile" element={<ProfileEdit />} />
              <Route path="editPassword" element={<ChangePassword />} />
              <Route path="order" element={<ProfileOrder />} />
            </Route>
          </Route>
        </Route>

        <Route element={<ProtectedLayout />}>
          <Route path="paymentsuccess/:id" element={<PaymentSuccessful />} />
        </Route>

        <Route element={<AdminLayout />}>
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="userManager" element={<UserManager />} />
          <Route path="revenueManager" element={<RevenueManager />} />
          <Route path="statisticalProduct" element={<StatisticalProduct />} />
        </Route>

        <Route element={<StaffLayout />}>
          <Route path="orderManager" element={<OrderManager />} />
          <Route path="reportHandle" element={<ReportManager />} />
        </Route>

        <Route element={<ManagerLayout />}>
          <Route path="productManager" element={<ProductManager />} />
          <Route path="createProduct" element={<CreateProduct />} />
        </Route>
      </Route>
    )
  );

  return (
    <>
      <RouterProvider router={router} />
      <ToastContainer />
    </>
  );
}

export default App;
