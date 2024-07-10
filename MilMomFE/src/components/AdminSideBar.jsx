import React from "react";
import { emptyAvatar, sideBarAdminData } from "../data/data";
import { Link, useLocation, useNavigate } from "react-router-dom";
import milmom from "../assets/milmom.png";
export default function AdminSideBar() {
  const location = useLocation()
  const navigate = useNavigate()
  return (
    <div className=" min-h-screen ">
      <div className="border-r border-neutral-200 rounded-lg pt-5 min-h-screen bg-red-100 px-1">
       <div className="flex items-center my-20">
        <img src={emptyAvatar} className="rounded-full w-3/12 mr-5"/>
        <div className="text-blue-950 font-bold text-xl">Admin</div>
       </div>
        {sideBarAdminData.map((data) => (
          <div onClick={() => navigate(data.link)} className={`w-full flex items-center rounded-xl py-1 px-5 mb-1 ${location.pathname==data.link?"bg-red-300":"bg-red-200"}`}>
            <div className={`w-10 block rounded-full bg-neutral-100 text-neutral-400 p-3 mr-7`}>
              {data.icon}
            </div>
            <div className={`text-center font-bold text-sm text-blue-950 `}>
              {data.content}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
