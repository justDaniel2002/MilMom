import React from "react";
import { blankAvatar, emptyAvatar, sideBarAdminData, sideBarStaffData } from "../data/data";
import { Link, useLocation, useNavigate } from "react-router-dom";
import milmom from "../assets/milmom.png";
export default function StaffSideBar() {
  const location = useLocation();
  const navigate = useNavigate();
  return (
    <div className=" min-h-screen ">
    <div className=" rounded-lg pt-5 min-h-screen bg-red-100 px-1">
     <div className="flex items-center my-20">
      <img src={emptyAvatar} className="rounded-full w-3/12 mr-5"/>
      <div className="text-blue-950 font-bold text-xl">Staff</div>
     </div>
      {sideBarStaffData.map((data) => (
        <div onClick={() => navigate(data.link)} className={`w-full rounded-xl py-2 px-5 mb-1 ${location.pathname==data.link?"bg-red-300":"bg-red-200"}`}>
         
          <div className={` font-bold text-sm text-blue-950 `}>
            {data.content}
          </div>
        </div>
      ))}
    </div>
  </div>
  );
}
