import React from "react";
import { ColumnChart } from "./ColumnChart";
import MilMomBtn from "./MilMomBtn";

export default function OrderChart() {
  return (
    <div>
      <div className="flex justify-between items-center mb-20">
        <div className="font-medium text-3xl">
          Thống kê doanh thu MilMom theo số đơn hàng
        </div>
        <MilMomBtn
          content="Xuất file"
          text="text-white"
          className="rounded-lg"
        />
      </div>

      <div className="rounded-xl overflow-hidden">
        <div className="flex justify-between items-center bg-red-200 py-1 px-5">
          <div className="font-medium text-xl">Bộ lọc</div>
          <div className="flex items-end">
            <div className="mr-3">
              <div className="text-sm mb-1">Thời gian bắt đầu</div>
              <input type="date" className="p-3 rounded-lg" />
            </div>

            <div className="mr-3">
              <div className="text-sm mb-1">Thời gian bắt đầu</div>
              <input type="date" className="p-3 rounded-lg" />
            </div>

            <select className="p-3">
              <option>Ngày</option>
              <option>Tuần</option>
              <option>Tháng</option>
            </select>
          </div>
        </div>

       <div className="bg-white py-5"> <ColumnChart /></div>
      </div>
    </div>
  );
}
