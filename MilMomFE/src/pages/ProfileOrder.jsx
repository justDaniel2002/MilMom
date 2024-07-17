import React, { useEffect, useState } from "react";
import { orderStatus } from "../data/data";
import { getService } from "../api/services";
import { getOrderByAccountId } from "../api/apis";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import OrderContainer from "../components/OrderContainer";

export default function ProfileOrder() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [selectedStatus, setSelectedStatus] = useState(-1);
  const [orders, setOrder] = useState([]);

  useEffect(() => {
    getService(getOrderByAccountId, [account?.userID]).then((res) => {
      const orderlist = res?.data;
      if (selectedStatus == -1) setOrder(res?.data);
      else setOrder(orderlist.filter((o) => o?.status == selectedStatus));
    });
  }, [selectedStatus]);

  return (
    <div>
      <div className="flex justify-around font-medium py-3 bg-white border border-neutral-400 text-xl">
        <div
          onClick={() => setSelectedStatus(-1)}
          className={`${selectedStatus == -1 ? "text-red-300" : ""}`}
        >
          Tất cả
        </div>{" "}
        {orderStatus.map((os) => (
          <div
            onClick={() => setSelectedStatus(os.id)}
            className={`${selectedStatus == os.id ? "text-red-300" : ""}`}
          >
            {os.content}
          </div>
        ))}
      </div>
      <div>
        {orders.map((order) => (
          <OrderContainer order={order} />
        ))}
      </div>
    </div>
  );
}
