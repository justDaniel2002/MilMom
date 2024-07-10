import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import MilMomBtn from "../components/MilMomBtn";
import { getService } from "../api/services";
import { getOrderById } from "../api/apis";
import { convertToCustomFormat } from "../helper/helper";
import Table, { cartHeader, orderHeader } from "../components/Table";

export default function PaymentSuccessful() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [order, setOrder] = useState();
  const params = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getService(getOrderById, [params.id]).then((result) => {
      console.log(result);
      setOrder(result.data);
    });
  });
  return (
    <div className="py-10 px-5 font-medium">
      <div className="font-bold text-xl text-center my-5">
        Tạo Đơn Hàng Thành Công
      </div>
      <div className="flex">
        <div className="w-2/3 px-3">
          <div className="mb-3 bg-slate-200 p-5">
            <div className="m-auto inline-block">
              <div>
                <span>Đơn hàng: </span>
                <span className="text-blue-500">22010124125521352</span>
              </div>
              <div>
                <span className="text-sm">
                  {convertToCustomFormat(order?.orderDate) ?? Date.now()}
                </span>
              </div>
            </div>
          </div>

          <div className="flex">
            <div className="w-1/3 border">
              <div className="bg-slate-200 p-3">KHÁCH HÀNG</div>
              <div className="p-3 pb-10">
                <div>{account?.name}</div>
                <div className="font-light">{account?.phone}</div>
              </div>
            </div>

            <div className="w-2/3 ml-3 border">
              <div className="bg-slate-200 p-3">NGƯỜI NHẬN</div>
              <div className="p-3 pb-10">
                <div>{order?.shippingInfor?.receiverName}</div>
                <div className="font-light">
                  <div><span className="font-medium">Địa chỉ: </span>{" "}
                  <span>{order?.shippingInfor?.detailAddress}</span></div>
                  <div className="text-sm">{`${order?.shippingInfor?.province} - ${order?.shippingInfor?.district} - ${order?.shippingInfor?.ward}`}</div>
                </div>
              </div>
              
            </div>
          </div>

          <div className="mt-5 border"><Table bg="bg-neutral-100" headerTable={orderHeader} isDelete={false} datas={order?.orderDetails}/></div>
        </div>
        <div className="w-1/3">
          <div className="mb-3 border">
            <div className="bg-slate-200 p-3">PHƯƠNG THỨC THANH TOÁN</div>
            <div className="text-center py-5 text-red-600">Ship Cod</div>
          </div>
          <div className="border p-3 mb-3 pb-40">
            <div className="flex justify-between">
              <div className="text-neutral-400">Thành tiền:</div>
              <div>2.550.000 đ</div>
            </div>

            <hr className="my-5" />

            <div className="flex justify-between items-center">
              <div>Cần thanh toán:</div>
              <div className="text-xl text-red-600">2.550.000 đ</div>
            </div>
            <div className="flex justify-between text-sm text-neutral-400">
              <div>(1 sản phẩm)</div>
              <div>(Đã bao gồm VAT)</div>
            </div>
          </div>

          <MilMomBtn
            content="Ghi chú"
            bg="bg-white"
            className="border py-3 mb-3"
          />
          <MilMomBtn
            onClick={() => navigate("/")}
            content="Quay lại trang chủ"
            className="text-white py-3"
          />
        </div>
      </div>
    </div>
  );
}
