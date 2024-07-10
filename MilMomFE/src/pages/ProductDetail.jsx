import React, { useCallback, useEffect, useMemo, useState } from "react";
import { DEFAULT_IMG, detailProduct, emptyAvatar } from "../data/data";
import { formatCurrency } from "../helpers/helper";
import MilMomBtn from "../components/MilMomBtn";

import { Icon } from "@iconify/react/dist/iconify.js";
import { useNavigate, useParams } from "react-router-dom";
import { getService, postService } from "../api/services";
import { getProductDetail, get_del_Cart_byAccountId } from "../api/apis";
import SliderReact from "../components/Slider";
import { toast } from "react-toastify";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";

export default function ProductDetail() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [product, setProduct] = useState();
  const [selectedImg, setSelectedImg] = useState(DEFAULT_IMG);
  const params = useParams();
  const navigate = useNavigate();
  const changeSelectedImage = useCallback((img) => {
    setSelectedImg(img);
  });

  const addToCart = useCallback((isNavigate = false) => {
    if (!account) {
      toast.info("Đăng nhập để có thể mua hàng");
      return;
    } else {
    }

    postService(get_del_Cart_byAccountId, {
      accountId: account?.userID,
      productId: params?.id,
    })
      .then(() => {
        toast.info(`${product.name} đã được thêm vào giỏ hàng của bạn`);
        if (isNavigate==true) navigate("/cart");
      })
      .catch((error) => {
        console.log(error);
      });
  });

  useEffect(() => {
    getService(getProductDetail, [params?.id]).then((result) => {
      setProduct(result.data);
      setSelectedImg(result.data.imageProducts[0].image);
    });
  }, [params]);
  return (
    <div className="py-10 px-40">
      <div className="flex items-center mb-20">
        <div className="w-1/2">
          <img className="mb-5 w-full" src={selectedImg} />

          <SliderReact
            onClickImg={changeSelectedImage}
            images={product?.imageProducts}
          />
        </div>
        <div className="w-1/2 px-10">
          <div className="text-4xl font-bold mb-3">{product?.name}</div>
          <div className="text-sm text-neutral-500 mb-20">
            {product?.original}
          </div>
          <div className="flex mb-5">
            <div className="text-3xl font-bold text-blue-950 mr-10">
              {formatCurrency(product?.purchasePrice ?? 0)}
            </div>
            <div className="px-2 py-1 bg-yellow-100 rounded-3xl mr-3 flex items-center text-yellow-400 text-sm">
              <Icon icon="material-symbols:star-outline" />
              <span className="ml-2">{product?.rating ?? 0}</span>
            </div>
            <div className="px-2 py-1 rounded-3xl bg-slate-100 flex items-center text-red-300 text-sm">
              <Icon
                icon="icon-park-outline:comment"
                className="text-blue-950"
              />
              <span className="ml-2">{0} đánh giá</span>
            </div>
          </div>

          <div className="flex mb-2">
            <div className="font-bold text-neutral-500 mr-28 line-through">
              {formatCurrency(product?.unitPrice ?? 0)}
            </div>
            <div className="px-2 py-1 flex items-center text-sm">
              <div className="text-green-700">93%</div>
              <span className="ml-2 text-neutral-500">
                Người đã mua và đánh giá
              </span>
            </div>
          </div>

          <hr className="my-5" />

          <div className="flex mb-20">
            <MilMomBtn
              onClick={async () => {
                addToCart(true);
              }}
              content="Mua Ngay"
              text="text-white"
              px="px-5"
              className="mr-5"
            />

            <div
              onClick={addToCart}
              className={`bg-red-300 rounded-md text-white font-medium px-5 py-2`}
            >
              <div className="flex items-center">
                {" "}
                <Icon icon="tdesign:shop" className="mr-3" /> Thêm vào giỏ hàng{" "}
              </div>
            </div>
          </div>

          <div className="rounded-lg border p-4 flex">
            <Icon icon="tdesign:shop" className="mr-3 text-red-300" />
            <div>
              <div className="font-bold text-blue-900">Hoàn trả hàng</div>
              <div className="text-sm text-neutral-500">
                Miễn đổi trả trong vòng 30 ngày kể từ ngày nhận hàng thành công.
                Chi tiết tại đây.
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="mb-20">
        <div className="text-4xl font-medium mb-10">
          Thông tin chi tiết sản phẩm
        </div>
        <div className="grid grid-cols-4 mb-5">
          <div className="p-5 font-medium border border-neutral-500">
            Tên sản phẩm
          </div>
          <div className="p-5 font-medium border border-neutral-500 col-span-3">
            {product?.name}
          </div>
          <div className="p-5 font-medium border border-neutral-500 bg-neutral-100">
            Nhà sản xuất
          </div>
          <div className="p-5 font-medium border border-neutral-500 col-span-3">
            {product?.supplier}
          </div>
          <div className="p-5 font-medium border border-neutral-500">
            Hướng dẫn sử dụng
          </div>
          <div className="p-5 font-medium border border-neutral-500 col-span-3">
            {product?.instruction}
          </div>
          <div className="p-5 font-medium border border-neutral-500 bg-neutral-100">
            Trọng lượng sản phẩm
          </div>
          <div className="p-5 font-medium border border-neutral-500 col-span-3">
            {product?.weight} g
          </div>
          <div className="p-5 font-medium border border-neutral-500">
            Thành phần
          </div>
          <div className="p-5 font-medium border border-neutral-500 col-span-3">
            {product?.ingredient}
          </div>
        </div>
      </div>

      <div>
        <div className="text-3xl font-medium mb-10">Đánh giá sản phẩm</div>
        <div className="flex">
          <div className="w-1/12 mr-1">
            <img src={emptyAvatar} />
          </div>

          <div>
            <div className="font-bold mb-1">Thùy Dương</div>
            <div className="flex text-yellow-500 items-center">
              <Icon icon="material-symbols:star" />
              <Icon icon="material-symbols:star" />
              <Icon icon="material-symbols:star" />
              <Icon icon="material-symbols:star" />
              <Icon icon="material-symbols:star" />
              <span className="ml-3 text-neutral-500">03/06/2024 13:05</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
