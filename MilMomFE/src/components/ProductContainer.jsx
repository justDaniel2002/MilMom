import React, { memo } from "react";
import { formatCurrency } from "../helpers/helper";
import { Icon } from "@iconify/react/dist/iconify.js";
import { DEFAULT_IMG } from "../data/data";

function ProductContainer({ product }) {
  return (
    <div className="rounded-xl shadow-lg">
      <div className="rounded-xl h-60 overflow-hidden">
        <img className="m-auto" src={product?.imageProducts?product?.imageProducts[0].image:DEFAULT_IMG} />
      </div>
     <div className="p-5">
     <div className="font-medium truncate">{product?.name}</div>
      <div className="flex text-yellow-500">
        <Icon icon="material-symbols:star" />
        <Icon icon="material-symbols:star" />
        <Icon icon="material-symbols:star" />
        <Icon icon="material-symbols:star" />
        <Icon icon="material-symbols:star" />
      </div>
      <div className="text-lg text-red-300 flex justify-between">
        <div>{formatCurrency(product?.purchasePrice??0)}</div>

        <Icon icon="mdi:cart" />
      </div>
     </div>
    </div>
  );
}

export default memo(ProductContainer)
