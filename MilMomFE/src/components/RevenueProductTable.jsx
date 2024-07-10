import React from "react";
import MilMomBtn from "./MilMomBtn";
import ManagerTable, { revenueProductHeader } from "./ManagerTable";
import Pagination from "./Pagination";

export default function RevenueProductTable() {
  return (
    <div>
      <div className="text-2xl font-medium mb-3">
        Thống kê doanh thu MilMom theo số lượng sản phẩm bán ra
      </div>
      <div className="flex justify-between items-center mb-20">
        <div className="flex p-1 bg-neutral-100">
          <MilMomBtn content="Hôm nay" />
          <MilMomBtn content="Ngày" />
          <MilMomBtn content="Tuần" />
          <MilMomBtn content="Tháng" />
        </div>

        <MilMomBtn
          content="Xuất file"
          text="text-white"
          className="rounded-lg"
        />
      </div>

      <div className="mb-10"><ManagerTable isDelete={false} datas={[]} headerTable={revenueProductHeader}/></div>

      <Pagination />

      <div className="mt-10">
        <MilMomBtn content="Tổng doanh thu     100,000,000đ"/>
      </div>
    </div>
  );
}
