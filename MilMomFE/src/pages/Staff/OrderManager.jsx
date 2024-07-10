import React, { memo, useCallback, useEffect, useRef, useState } from "react";
import {
  accountList,
  accountType,
  orderList,
  orderStatus,
} from "../../data/data";
import MilMomBtn from "../../components/MilMomBtn";
import Pagination from "../../components/Pagination";
import { getCurrentDate } from "../../helper/helper";
import ManagerTable, {
  orderManagerHeader,
} from "../../components/ManagerTable";
import axios from "axios";
import { getOrderByDate, updateOrderStatus } from "../../api/apis";
import { getService, putService } from "../../api/services";
import { useNavigate } from "react-router-dom";

function OrderManager() {
  const [date, setDate] = useState(undefined);
  const [status, setStatus] = useState(undefined);
  const [orders, setOrder] = useState([]);

  const navigate = useNavigate()
  const getOrders = useCallback(() => {
    getService(
      `${getOrderByDate}?${date!=undefined? `date=${date}&`:``}${
        status!=undefined?  `status=${status}`:``
      }`
    ).then((result) => {
      setOrder(result.data);
    });
  }, [status, date]);
  const Completed   = useCallback(( order) => {
  putService(`${updateOrderStatus}?orderId=${order.orderID}&status=4`).then(() => {
    getOrders()
  })
  },[status,date])

  const Cancelled  = useCallback(( order) => {
    putService(`${updateOrderStatus}?orderId=${order.orderID}&status=5`).then(() => {
      getOrders()
    })
    },[])
  useEffect(() => {
    getOrders();
  }, [status, date]);
  return (
    <div className="py-5">
      <div className="py-5 bg-red-100 rounded-lg min-h-screen text-sm">
        <div className="text-3xl font-medium mb-5">Quản lý đơn hàng</div>
        <div className="flex font-medium my-10 text-lg">
          {orderStatus.map((s) => (
            <div onClick={() => setStatus(s.id)} className="w-1/6 px-1">
              <div className={`rounded-xl text-center py-5 ${s.color}`}>
                {s.content}
              </div>
            </div>
          ))}
        </div>
        <div className="flex items-center justify-between mb-10 px-20">
          <div className="flex w-2/5">
          
            <input
              className="border rounded-md px-3 py-1 text-neutral-500 w-2/5"
              placeholder="filter theo ngày"
              type="date"
              onChange={(event) => {
                setDate(event.target.value);
                console.log(event.target.value);
              }}
            />
          </div>
          <MilMomBtn
          onClick={() => navigate('/cart')}
            content="Tạo mới"
            text="text-white"
            font="font-base"
            className="rounded-lg"
          />
        </div>
        <div className="px-20">
          <ManagerTable onDelete={Cancelled} onApprove={Completed} deleteContent="Hủy" approveContent="Xác nhận" datas={orders} headerTable={orderManagerHeader} />
        </div>

        <div className="mt-20">
          {/* <Pagination /> */}
        </div>
      </div>
    </div>
  );
}

export default memo(OrderManager);
