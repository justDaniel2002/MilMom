import React, { memo, useEffect, useState } from "react";
import ProductContainer from "./ProductContainer";
import { detailProduct } from "../data/data";
import { getService } from "../api/services";
import { getViewProduct } from "../api/apis";
import { useNavigate } from "react-router-dom";

const OtherProducts = () => {
  const [products, setProducts] = useState([]);
  const navigate = useNavigate()
  useEffect(() => {
    getService(getViewProduct).then((result) => setProducts(result.data));
  }, []);
  return (
    <div>
      <div className="text-red-300 font-bold text-3xl">Các sản phẩm khác</div>
      <div className="text-neutral-400 font-bold text-2xl text-right">
        Xem tất cả
      </div>

      <div className="flex flex-wrap">
        {products?.slice(0, 8)?.map((pro, index) => (
          <div onClick={() => navigate(`/productDetail/${pro.productId}`)} key={index} className="w-1/4 px-5 mb-10">
            <ProductContainer product={pro} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default memo(OtherProducts);
