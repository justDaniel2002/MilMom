import React from "react";
import { accountList, accountType, orderList, reportList } from "../../data/data";
import MilMomBtn from "../../components/MilMomBtn";
import Pagination from "../../components/Pagination";
import { getCurrentDate } from "../../helper/helper";
import ManagerTable, {  reportManagerHeader } from "../../components/ManagerTable";

export default function ReportManager() {
  return (
    <div className="py-5">
        <div className="py-5 px-20 bg-white rounded-lg min-h-screen text-sm">
      <div className="text-2xl font-medium mb-5">
      Xử lý Report
      </div>
      <div className="flex items-center justify-between mb-10">
          
          <input
            className="border rounded-md px-3 py-1 text-neutral-500 w-2/5"
            placeholder="tìm kiếm report theo mã đơn hàng"
          />
      </div>
      <ManagerTable datas={reportList} headerTable={reportManagerHeader} />

      <div className="mt-20">
        <Pagination />
      </div>
    </div>
    </div>
  );
}
