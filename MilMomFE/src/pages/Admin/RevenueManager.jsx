import React, { useState } from "react";
import MilMomBtn from "../../components/MilMomBtn";
import { ColumnChart } from "../../components/ColumnChart";
import OrderChart from "../../components/OrderChart";

export default function RevenueManager() {
  const [section, setSection] = useState("Đơn Hàng")
  return (
    <div className="bg-red-100 px-10 py-10 ">
      <div className="flex items-center">
        <MilMomBtn onClick={() => setSection("Đơn Hàng")} content="Đơn Hàng"/>
        <MilMomBtn onClick={() => setSection("Sản phẩm")} content="Sản phẩm"/>
      </div>
      
      {section=="Đơn Hàng"&&<OrderChart />}
    </div>
  );
}
