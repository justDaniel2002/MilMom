import React, { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import Navbar from "../components/Navbar";
import Footer from "../components/Footer";
import { accountAtom } from "../atom/accountAtom";
import { useRecoilState } from "recoil";

export default function MainLayout() {
  const [account, setAccount] = useRecoilState(accountAtom);

  const navigate = useNavigate();
  useEffect(() => {
    if (account?.roles.includes("Admin")) {
      navigate("/dashboard");
    } else if (account?.roles.includes("Staff")) {
      navigate("/orderManager");
    } else if (account?.roles.includes("Manager")) {
      navigate("/productManager");
    } 
  });
  return (
    <>
      <Navbar />
      <Outlet />
      <Footer />
    </>
  );
}
