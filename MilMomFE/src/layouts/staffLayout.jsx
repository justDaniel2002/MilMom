import React from "react";
import AdminSideBar from "../components/AdminSideBar";
import AdminNav from "../components/AdminNav";
import { Outlet } from "react-router-dom";
import StaffSideBar from "../components/StaffSideBar";
import Navbar from "../components/Navbar";

export default function StaffLayout() {
  return (
    <div>
      <Navbar />
      <div className="px-5 flex bg-red-100">
        <div className="w-1/6 mr-5 border-r-2 border-neutral-200 pr-5">
          <StaffSideBar />
        </div>
        <div className="w-5/6">
          <Outlet />
        </div>
      </div>
    </div>
  );
}
