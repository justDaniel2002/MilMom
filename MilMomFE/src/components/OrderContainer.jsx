import React from "react";
import { formatCurrency } from "../helpers/helper";
import MilMomBtn from "./MilMomBtn";
import { useNavigate } from "react-router-dom";

export default function OrderContainer({ order }) {
  const navigate = useNavigate()
  return (
    <>
      {order?.orderDetails.map((od) => (
        <div className="rounded-lg font-medium  border bg-white border-neutral-400 mb-5">
          <div className="flex justify-between p-3">
            <div>ORDER-ID: {order?.orderID}</div>
            <div>{StatusGen(order?.status)}</div>
          </div>

          <div className="flex justify-between p-3 border">
            <div className="flex">
              <img className="w-1/12" src={od?.product?.imageProducts[0]?.image} />
              <div className="text-xl">
                <div>{od?.product?.name}</div>
                <hr className="my-5" />
                <div>SỐ LƯỢNG: {od?.quantity}</div>
              </div>
            </div>
            <div className="text-xl flex flex-col items-center justify-between">
              <div className="text-nowrap">GIÁ THÀNH</div>
              <div className="text-nowrap">{formatCurrency(od?.unitPrice)} VND</div>
            </div>
          </div>
          <div className="p-3">
            <div className="flex justify-end text-red-400">
              THÀNH TIỀN {formatCurrency(od?.totalAmount)} VND
            </div>
            <div className="flex justify-end mt-3">
              {order?.status == 4 ? (
                <>
                  <MilMomBtn content="ĐÁNH GIÁ" className="rounded-xl mx-2 border border-black" />
                  <MilMomBtn
                  onClick={() => navigate(`/productDetail/${od?.product?.productID}`)}
                    content="MUA LẠI"
                    bg="bg-white"
                    className="rounded-xl mx-2 border border-black"
                  />
                  <MilMomBtn
                    content="TRẢ HÀNG"
                    bg="bg-white"
                    className="rounded-xl mx-2 border border-black"
                  />
                  <MilMomBtn
                    content="KHIẾU NẠI"
                    bg="bg-white"
                    className="rounded-xl mx-2 border border-black"
                  />
                </>
              ) : order?.status == 0 || order?.status == 1 ? (
                <>
                  <MilMomBtn
                    content="HỦY ĐƠN"
                    bg="bg-white"
                    className="rounded-xl mx-2 border border-black"
                  />
                </>
              ) : order?.status == 7 ? (
                <>
                  <MilMomBtn content="CHI TIẾT" className="rounded-xl mx-2" />
                  <MilMomBtn
                    content="HỦY"
                    bg="bg-white"
                    className="rounded-xl mx-2 border border-black"
                  />
                </>
              ) : (
                <></>
              )}
            </div>
          </div>
        </div>
      ))}
    </>
  );
}

const StatusGen = (status) => {
  switch (status) {
    case 0:
      return <span className="text-yellow-500">CHỜ THANH TOÁN </span>;
    case 1:
      return <span className="text-yellow-500">CHỜ XÁC NHẬN </span>;
    case 2:
      return <span className="text-yellow-500">ĐANG GIAO HÀNG </span>;
    case 3:
      return <span className="text-green-500">ĐÃ HOÀN TẤT </span>;
    case 4:
      return <span className="text-red-500">CHỜ HOÀN TIỀN </span>;
    case 5:
      return <span className="text-red-500">YÊU CẦU TRẢ HÀNG</span>;
    case 6:
      return <span className="text-red-500">ĐÃ HỦY </span>;
  }
};
