import React, { memo, useEffect, useState } from "react";
import AreaChartComponent from "../../components/AreaChart";
import { COLORS, PieChartComponent, data } from "../../components/Piechart";
import { staticDashboard } from "../../data/data";
import { getService } from "../../api/services";
import { getStaticOrders, getStoreRevenueByMonth, getTopProductsSoldInMonth, getTotalAcc, getTotalProductOfWeek } from "../../api/apis";
import { Icon } from "@iconify/react/dist/iconify.js";

function Dashboard() {
  const [totalStatic, setTotalStatic] = useState();
  const [orderStatic, setOrderStatic] = useState([]);
  const [topProductSold, setTopProductSold] = useState([])
  const [revenueByMonth, setRevenueByMoneth] = useState([])
  const [totalAcc, setTotalAcc] = useState([])

  useEffect(() => {
    getService(getTotalProductOfWeek).then((result) =>
      setTotalStatic(result.data)
    );
    getService(getStaticOrders).then((result) => {
      setOrderStatic([
        {
          name: "Đơn Hàng Đã Giao Thành Công",
          value: result.data.ordersComplete,
        },
        {
          name: "Đơn Hàng Bị Hủy",
          value: result.data.ordersCancell,
        },
        {
          name: "Đơn Hàng Được Hoàn Trả",
          value: result.data.ordersReturnRefund,
        },
        {
          name: "Đơn Hàng Có Khiếu Nại / Report",
          value: result.data.ordersReport,
        },
      ]);
    });

    getService(getTopProductsSoldInMonth).then(result => setTopProductSold(result.data.topProducts))

    getService(getStoreRevenueByMonth).then(result => {
      const monthlist = result.data.monthList

      const rbm = monthlist.map(ml => ({
        name: ml.item1,
        static:ml.item2
      }))

      setRevenueByMoneth(rbm)
    })

    getService(getTotalAcc).then(result => setTotalAcc(result.data))
  }, []);
  return (
    <div className="py-10">
      <div className="flex items-center">
        {staticDashboard.map((info) => (
          <div className="rounded-xl w-1/4 mr-10 bg-white px-5 py-7 flex items-center">
            <div
              className={`${info.iconColor} p-3 rounded-full mr-3 text-white text-xl`}
            >
              {info.icon}
            </div>
            <div>
              <div className="text-xs font-light mb-1 text-neutral-500">
                {info.content}
              </div>
              <div className="font-medium text-xl tracking-wider">
                {totalStatic?.[info.value]
                  ? info.format
                    ? info.format(totalStatic[info.value])
                    : totalStatic[info.value]
                  : info.value}
              </div>
            </div>
          </div>
        ))}

        <div className="rounded-xl w-1/4 mr-10 bg-white px-5 py-7 flex items-center">
          <div
            className={`bg-green-300 p-3 rounded-full mr-3 text-white text-xl`}
          >
            <Icon icon="bx:bar-chart" />
          </div>
          <div>
            <div className="text-xs font-light mb-1 text-neutral-500">
              Số Lượng Đơn Hàng Bị Hủy/ Trả Trong Tuần
            </div>
            <div className="font-medium text-xl tracking-wider">
              {orderStatic?.ordersReturnRefund ?? 0}
            </div>
          </div>
        </div>
      </div>
      <div className="flex py-10">
        <div className="w-2/3 mr-5 rounded-xl border font-medium p-5 bg-white">
          <div className="flex items-center">
            <div className="w-1/3">
              <div>Statistics</div>
              <PieChartComponent data={orderStatic} />
            </div>
            <div className="w-2/3 grid grid-cols-2 gap-5">
              {orderStatic.map((d) => (
                <div className="text-right">
                  <div className="font-light inline-flex items-center">
                    <span
                      style={{ backgroundColor: d.color }}
                      className="inline-block rounded-full w-2 h-2 text-xs mr-2"
                    >
                      .
                    </span>
                    {d.name}
                  </div>
                  <div>{d.value}</div>
                </div>
              ))}
            </div>
          </div>
        </div>

        <div className="w-1/3 border rounded-xl p-5 bg-white">
          <div className="flex justify-between items-end">
            <div className="font-medium text-lg">Sản phẩm bán chạy </div>
            <div className="font-light">See ranking</div>
          </div>

          <div className="my-5">
            {topProductSold.slice(0, 4).map((d, index) => (
              <div className="flex items-center justify-between mb-5">
                <div className="flex items-center">
                  <div
                    className={`font-bold text-white rounded-xl px-3 py-2 mr-3`}
                    style={{ backgroundColor: `${COLORS[index]}` }}
                  >
                    {index + 1}
                  </div>
                  <div>{d.item1}</div>
                </div>

                <div>{d.item2}</div>
              </div>
            ))}
          </div>
        </div>
      </div>

      <div className="flex mt-5 font-medium">
        <div className="w-2/3 mr-5 h-96 rounded-xl border font-medium bg-white p-5">
          <div className="mb-10">Overview</div>
          <AreaChartComponent data={revenueByMonth} />
        </div>
        <div className="w-1/3 border rounded-xl p-5 bg-white">
          <div className="mb-10 text-lg">Số lượng tài khoản người dùng</div>
          <div className="flex items-end mb-10">
            <div className="font-bold text-2xl mr-2">{totalAcc.totalAccount}</div>
            <div className="font-light text-sm">tài khoản</div>
          </div>

          <div class="w-full bg-red-200 rounded-full h-4 mb-10">
            <div
              class="bg-red-400 h-4 rounded-full"
              style={{ width: "45%" }}
            ></div>
          </div>

          <div className="grid grid-cols-2 font-light">
            <div>
              <div>Manager</div>
              <div className="font-bold">{totalAcc.staffsAccount}</div>
            </div>
            <div>
              {" "}
              <div>Staff</div>
              <div className="font-bold">{totalAcc.managersAccount}</div>
            </div>
            <div>
              {" "}
              <div>Customer</div>
              <div className="font-bold">{totalAcc.customersAccount}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default memo(Dashboard);
