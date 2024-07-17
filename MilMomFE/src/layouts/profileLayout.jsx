import React from "react";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { emptyAvatar, sideBarProfileData } from "../data/data";
import MilMomBtn from "../components/MilMomBtn";
import { Outlet, useNavigate } from "react-router-dom";

export default function ProfileLayout() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const navigate = useNavigate();
  return (
    <div className="bg-red-100 px-20 pb-40 pt-10 flex">
      <div className="w-1/5 px-10">
        <div className="flex items-center">
          <img src={emptyAvatar} className="w-1/6 mr-5 rounded-full" />
          <div className="font-medium text-xl">{account?.userName}</div>
        </div>
        <div className="font-medium pt-2 pb-10">{account?.email}</div>
        {sideBarProfileData.map((data) => (
          <div
            onClick={() => navigate(data.link)}
            className={`w-full flex items-center rounded-xl py-1 px-5 mb-1 ${
              location.pathname == data.link ? "bg-red-300" : "bg-red-100"
            }`}
          >
            <div
              className={`w-10 block rounded-full bg-neutral-100 text-neutral-400 p-3 mr-7`}
            >
              {data.icon}
            </div>
            <div className={`text-center font-bold text-sm text-blue-950 `}>
              {data.content}
            </div>
          </div>
        ))}
      </div>
      <div className="w-4/5">
        <div className="flex pt-5 justify-end">
          <MilMomBtn
            onClick={() => {
              localStorage.removeItem("account");
              setAccount(undefined);
            }}
            content="Đăng xuất"
            className="rounded-md text-xl"
          />
        </div>
        <hr className="my-10 border border-neutral-400" />
        <div className="px-5">
          <Outlet />
        </div>
      </div>
    </div>
  );
}
