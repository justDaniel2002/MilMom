import React, { useEffect, useState } from "react";
import { accountList, accountType } from "../../data/data";
import MilMomBtn from "../../components/MilMomBtn";
import Pagination from "../../components/Pagination";
import ManagerTable, { userManagerHeader } from "../../components/ManagerTable";
import { getService } from "../../api/services";
import { getAllAccount } from "../../api/apis";

export default function UserManager() {
  const [accounts, setAccounts] = useState([])
  useEffect(() => {
    getService(getAllAccount).then(res => setAccounts(res))
  },[])
  return (
    <div className="py-5">
        <div className="py-5 px-20 bg-white rounded-lg min-h-screen text-sm">
      <div className="text-2xl font-medium mb-5">
        Quản lý tài khoản người dùng
      </div>
      <div className="flex items-center justify-between mb-10">
        <div className="flex items-center w-5/6">
          <div className="font-medium bg-slate-100 px-3 py-1 mr-10">
            <span className="px-3 py-3">View all</span>
            {accountType.map((type) => (
              <span className="px-3 py-3">{type.content}</span>
            ))}
          </div>
          <input
            className="border rounded-md px-3 py-1 text-neutral-500 w-2/5"
            placeholder="tìm kiếm tài khoản người dùng"
          />
        </div>
        <MilMomBtn
          content="Tạo mới"
          text="text-white"
          font="font-base"
          className="rounded-lg"
        />
      </div>
      <ManagerTable datas={accounts} headerTable={userManagerHeader} isDelete={false} approveContent="Thay đổi trạng thái"/>

      <div className="mt-20">
        <Pagination />
      </div>
    </div>
    </div>
  );
}
