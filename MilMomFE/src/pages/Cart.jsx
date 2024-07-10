import React, { useCallback, useEffect, useMemo, useState } from "react";
import Table, { cartHeader } from "../components/Table";
import { detailProduct } from "../data/data";
import MilMomBtn from "../components/MilMomBtn";
import ProductContainer from "../components/ProductContainer";
import OtherProducts from "../components/OtherProducts";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { deleteService, getService, postService } from "../api/services";
import { checkout, get_del_Cart_byAccountId } from "../api/apis";
import { provinesAtom } from "../atom/provinesAtom";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { formatCurrency } from "../helpers/helper";

export default function Cart() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [provines, setProvines] = useRecoilState(provinesAtom);
  const [reciveAccount, setRAcc] = useState();
  const [cart, setCart] = useState([]);
  const [seletedProvine, setSelectedProvine] = useState();
  const [selectedDistric, setSelectedDistric] = useState();
  const [selectedWard, setSelectedWard] = useState();
  const navigate = useNavigate();

  const total = useMemo(() => {
    const totalPrice = cart.reduce((accumulator, item) => {
      return accumulator + item.product.purchasePrice;
    }, 0);
    return totalPrice;
  }, [cart]);

  const buy = useCallback(() => {
    if (!cart || cart?.length < 1) {
      toast.warning("Giỏ hàng của bạn trống");
      return;
    }

    const entries = Object.entries(reciveAccount);

    for (const [key, value] of entries) {
      if (!value || value?.trim() == "") {
        toast.warning(`${key} không được để trống`);
        return;
      }
    }

    if (!seletedProvine || !selectedDistric || !selectedWard) {
      toast.warning("Nhập đầy đủ địa chỉ");
      return;
    }

    postService(`${checkout}?accountId=${account.userID}`, {
      ...reciveAccount,
      provinceCode: seletedProvine.id,
      ward: selectedWard.name,
      district: selectedDistric.name,
      province: seletedProvine.name,
    })
      .then((result) => {
        console.log(result);
        getCart();
        window.open(result, "_blank");
      })
      .catch((error) => {
        console.log(error);
      });
  });

  const deleteFromCart = useCallback((data) => {
    deleteService(get_del_Cart_byAccountId, {
      accountId: account?.userID,
      productId: data?.product?.productID,
    })
      .then(() => {
        toast.success(`Xóa sản phẩm khỏi giỏ hàng`);
        getCart();
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const getCart = useCallback(() => {
    getService(get_del_Cart_byAccountId, [account?.userID]).then((result) => {
      console.log("cart", result);
      setCart(result.data.cartItem);
    });
  }, []);

  const onChangeProvine = (id) => {
    const pro = provines.find((p) => p.id == id);
    setSelectedProvine(pro);
    setSelectedDistric(pro.data2[0]);
    setSelectedWard(pro.data2.data3[0]);
  };

  const onChangeDistric = (id) => {
    const dis = seletedProvine.data2.find((d) => d.id == id);
    setSelectedDistric(dis);
    setSelectedWard(dis.data3[0]);
  };

  useEffect(() => {
    getCart();
    setRAcc({
      detailAddress: account.address,
      phone: account.phone,
      receiverName: account.name,
    });
  }, []);

  useEffect(() => {
    setSelectedProvine(provines[0]);
    setSelectedDistric(provines[0]?.data2[0]);
    setSelectedWard(provines[0]?.data2[0]?.data3[0]);
  }, [provines]);
  return (
    <div className="px-5">
      <div className="text-red-300 font-bold text-2xl mb-5">
        Giỏ hàng của bạn
      </div>
      <div className="flex mb-10">
        <div className="w-4/5 border flex flex-col justify-between border-black rounded-xl overflow-hidden mr-5 text-sm">
          <Table
            indexHeader={"STT"}
            headerTable={cartHeader}
            datas={cart}
            onDelete={deleteFromCart}
            next={getCart}
          />
          <div className="flex justify-between items-end px-5 pt-20 pb-10">
            <div className="w-1/4 font-medium">
              <div className="flex justify-between">
                <span className="text-neutral-400">Tạm tính</span>
                <span>{formatCurrency(total)}</span>
              </div>
              <hr className="my-3" />
              <div className="flex justify-between">
                <span>Tổng tiền</span>
                <span>{formatCurrency(total)}</span>
              </div>
            </div>

            <div className="w-1/5">
              <MilMomBtn
                content="Mua hàng"
                className="rounded-3xl border border-black py-2 mb-2"
                onClick={buy}
              />
              <MilMomBtn
                content="Mua thêm"
                className="rounded-3xl border border-black py-2 bg-slate-200"
                onClick={() => navigate("/")}
              />
            </div>
          </div>
        </div>
        <div className="w-1/5 font-medium">
          <div className="border bg-red-300 border-black rounded-xl p-3 mb-5">
            <div className="text-lg mb-3 text-center">Thông tin người nhận</div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Họ và tên: </div>
              <input
                value={reciveAccount?.receiverName}
                onChange={(event) =>
                  setRAcc({
                    ...reciveAccount,
                    receiverName: event.target.value,
                  })
                }
                placeholder="Họ và tên"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              />
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Số điện thoại: </div>
              <input
                placeholder="Số điện thoại"
                onChange={(event) =>
                  setRAcc({ ...reciveAccount, phone: event.target.value })
                }
                value={reciveAccount?.phone}
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              />
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Thành phố - Tỉnh: </div>
              <select
                value={seletedProvine?.id}
                onChange={(event) => onChangeProvine(event.target.value)}
                placeholder="Địa chỉ"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              >
                {provines?.map((pro) => (
                  <option value={pro.id}>{pro.name}</option>
                ))}
              </select>
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Xã - Huyện: </div>
              <select
                value={selectedDistric?.id}
                onChange={(event) => onChangeDistric(event.target.value)}
                placeholder="Địa chỉ"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              >
                {seletedProvine?.data2?.map((dis) => (
                  <option value={dis.id}>{dis.name}</option>
                ))}
              </select>
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Phường - Quận: </div>
              <select
                value={selectedWard?.id}
                onChange={(event) => {
                  const ward = selectedDistric?.data3.find(
                    (w) => w.id == event.target.value
                  );
                  setSelectedWard(ward);
                }}
                placeholder="Địa chỉ"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              >
                {selectedDistric?.data3?.map((ward) => (
                  <option value={ward.id}>{ward.name}</option>
                ))}
              </select>
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Địa chỉ: </div>
              <input
                value={reciveAccount?.detailAddress}
                onChange={(event) =>
                  setRAcc({
                    ...reciveAccount,
                    detailAddress: event.target.value,
                  })
                }
                placeholder="Địa chỉ"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              />
            </div>
            <div className="mb-3">
              <div className="pl-2 mb-2">Ghi chú (nếu có): </div>
              <input
                placeholder="Ghi chú"
                className="text-neutral-500 w-full px-5 py-2 border border-black rounded-xl"
              />
            </div>
          </div>
          <div className="border border-black rounded-xl p-3 bg-red-300 font-medium text-sm">
            <div className="text-center mb-3">Chọn phương thức thanh toán</div>

            <div className="bg-white border flex items-center py-2 px-5 border-black rounded-2xl w-full mb-3">
              <input className="mr-7" name="payment" type="radio" />{" "}
              <span>Ship Cod</span>
            </div>
            <div className="bg-white border flex items-center py-2 px-5 border-black rounded-2xl w-full">
              <input className="mr-7" name="payment" type="radio" />{" "}
              <span>VNPay</span>
            </div>
          </div>
        </div>
      </div>

      <OtherProducts />
    </div>
  );
}
