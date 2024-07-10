import React, { memo, useCallback } from "react";
import { formatCurrency } from "../helpers/helper";
import { Icon } from "@iconify/react/dist/iconify.js";
import { toast } from "react-toastify";
import axios from "axios";
import { get_del_Cart_byAccountId } from "../api/apis";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";

export const cartHeader = [
  {
    content: "Tên sản phẩm",
    id: "name",
    width: "w-4/12",
    format: (cart, next=undefined) => cart.product.name,
  },
  {
    content: "Hình ảnh",
    id: "image",
    format: (cart, next=undefined) => (
      <img
        className="m-auto"
        src={
          cart.product?.imageProducts?.length > 0 &&
          cart.product?.imageProducts[0].image
        }
      />
    ),
    width: "w-3/12",
  },
  {
    content: "Số lượng",
    format: (cart, next=undefined) => {
      const [account, setAccount] = useRecoilState(accountAtom)
      const updateCart = useCallback((action) => {
        if(action=='minus'&&cart.quantity<=1){
          return
        }
        if(action=='plus'&&cart.quantity>=99){
          return
        }

        if(action=='minus'){
          axios.put(`https://localhost:7101/api${get_del_Cart_byAccountId}/${account.userID}?productId=${cart.product.productID}&newQuantity=${cart.quantity-1}`).then(() => next())
          return
        }

        if(action=='plus'){
          axios.put(`https://localhost:7101/api${get_del_Cart_byAccountId}/${account.userID}?productId=${cart.product.productID}&newQuantity=${cart.quantity+1}`).then(() => next())
          return
        }
      })
      return (
        <div className="flex items-center justify-between">
          <Icon onClick={() => updateCart('minus')} icon="ic:baseline-minus" />
          <span>{cart.quantity}</span>
          <Icon onClick={() => updateCart('plus')} icon="ic:baseline-plus" />
        </div>
      );
    },
    width: "w-1/12",
  },
  {
    content: "Đơn giá",
    id: "price",
    format: (cart, next=undefined) => <>{formatCurrency(cart.product?.unitPrice)}</>,
    width: "w-2/12",
  },
  {
    content: "Tổng tiền",
    id: "price",
    format: (cart, next=undefined) => (
      <>{formatCurrency(cart.product?.unitPrice * cart.quantity)}</>
    ),
    width: "w-2/12",
  },
];

export const orderHeader = [
  {
    content: "Tên sản phẩm",
    id: "name",
    width: "w-6/12",
    header: () => <div className="pl-3 flex justify-start">Tên sản phẩm</div>,
    format: (cart, next=undefined) => <div className="flex justify-start pl-3">{cart.product.name}</div>,
  },
  {
    content: "Số lượng",
    id: "quantity", 
    width: "w-3/12",
  },
  {
    content: "Đơn giá",
    id: "price",
    format: (cart, next=undefined) => <>{formatCurrency(cart.product?.purchasePrice)}</>,
    width: "w-2/12",
  },
  {
    content: "Tổng tiền",
    id: "price",
    format: (cart, next=undefined) => (
      <>{formatCurrency(cart.product?.purchasePrice * cart.quantity)}</>
    ),
    width: "w-2/12",
  },
];


function Table({indexHeader=undefined, bg="bg-red-300", headerTable, datas=[], isDelete = true, onDelete = () => {}, next = () => {} }) {
  return (
    <div>
      <table>
        <thead>
          <tr className={`${bg} px-5`}>
            {indexHeader&&<td className="py-3 text-center px-3">{indexHeader}</td>}
            {headerTable.map((header) => (
              <th className={`py-3 text-center px-2 ${header?.width}`}>
                {header?.header?header.header():header?.content}
              </th>
            ))}
            {isDelete && <td className="px-3">Xóa</td>}
          </tr>
        </thead>
        <tbody>
          {datas
            ? datas?.map((data, index) => (
                <tr className="font-medium border-b border-black">
                  {indexHeader&&<td className="text-center py-10">{index + 1}</td>}
                  {headerTable.map((header) => (
                    <td className="text-center py-10">
                      {header?.format ? header.format(data, next) : data[header?.id]}
                    </td>
                  ))}
                  {isDelete && (
                    <td>
                      <button onClick={() => onDelete(data)}>Xóa</button>
                    </td>
                  )}
                </tr>
              ))
            : ""}
        </tbody>
      </table>
    </div>
  );
}




export default memo(Table);
