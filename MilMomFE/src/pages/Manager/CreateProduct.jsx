import React, { useCallback, useEffect, useState } from "react";
import MilMomBtn from "../../components/MilMomBtn";
import { convertDateFormat, convertToIOFormat, validateProduct } from "../../helper/helper";
import { getService, postService } from "../../api/services";
import { addForManager, getAllCate } from "../../api/apis";
import { toast } from "react-toastify";
import { handleUpload } from "../../cloudinary/cloudinary";
import { name } from "@cloudinary/url-gen/actions/namedTransformation";

export default function CreateProduct({
  onAbort = () => {},
  onSubmit = () => {},
}) {
  const [product, setProduct] = useState({categoryID:1, status: true});
  const [images, setImages] = useState();
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    getService(getAllCate).then((result) => setCategories(result.data));
  }, []);
  const addProduct = useCallback(async () => {
    if (validateProduct(product)) {
      if (images == undefined || !images?.length > 0) {
        toast.warning("Thêm ảnh cho sản phẩm");
        return;
      }
      const imgUrl = await handleUpload(images[0]);

      if (imgUrl == undefined) {
        toast.error("Đăng ảnh thất bại");
        return;
      }

      setProduct({ ...product, imageProducts: [{ image: imgUrl }] });

      postService(addForManager, product).then(res => {
        toast.success("Đã thêm mới sản phẩm")
        onAbort();
      });

      onSubmit();
    }
  },[product, images]);
  return (
    <div className="py-10 px-20 bg-white rounded-md">
      <div className="text-center text-4xl font-medium mb-10">
        Tạo mới sản phẩm
      </div>
      <div className="grid grid-cols-2">
        <div className="mb-20">
          <div className="mb-2 font-medium">Tên sản phẩm </div>
          <input
            value={product?.name}
            onChange={(event) =>
              setProduct({ ...product, name: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Số lượng trong kho </div>
          <input
            value={product?.inventoryQuantity}
            type="number"
            min={0}
            max={100}
            onChange={(event) =>
              setProduct({ ...product, inventoryQuantity: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Mô tả sản phẩm </div>
          <input
            value={product?.description}
            onChange={(event) =>
              setProduct({ ...product, description: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Giá nhập hàng</div>
          <input
            value={product?.unitPrice}
            type="number"
            min={1}
            onChange={(event) =>
              setProduct({ ...product, unitPrice: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Giá bán ra </div>
          <input
            value={product?.purchasePrice}
            type="number"
            min={1}
            onChange={(event) =>
              setProduct({ ...product, purchasePrice: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Nhãn hàng </div>
          <input
            value={product?.supplier}
            onChange={(event) =>
              setProduct({ ...product, supplier: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Xuất xứ </div>
          <input
            value={product?.original}
            onChange={(event) =>
              setProduct({ ...product, original: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Ngày hết hạn </div>
          <input
            value={convertDateFormat(product?.expiredDate)}
            type="date"
            onChange={(event) =>
              setProduct({ ...product, expiredDate: convertToIOFormat(event.target.value) })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Thành phần </div>
          <input
            value={product?.ingredient}
            onChange={(event) =>
              setProduct({ ...product, ingredient: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Hướng dẫn sử dụng</div>
          <input
            value={product?.instruction}
            onChange={(event) =>
              setProduct({ ...product, instruction: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Cân nặng </div>
          <input
            value={product?.weight}
            type="number"
            min={1}
            placeholder="g"
            step={0.1}
            onChange={(event) =>
              setProduct({ ...product, weight: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Chiều cao </div>
          <input
            value={product?.height}
            type="number"
            min={1}
            placeholder="cm"
            onChange={(event) =>
              setProduct({ ...product, height: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>
        <div className="mb-20">
          <div className="mb-2 font-medium">Chiều rộng </div>
          <input
            value={product?.width}
            type="number"
            min={1}
            placeholder="cm"
            onChange={(event) =>
              setProduct({ ...product, width: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          />
        </div>

        <div className="mb-20">
          <div className="mb-2 font-medium">Loại </div>
          <select
            onChange={(event) =>
              setProduct({ ...product, categoryID: event.target.value })
            }
            value={product?.categoryID}
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
          >
            {categories?.map(cate => <option value={cate?.categoryID}>{cate?.name}</option>)}
          </select>
        </div>
      </div>
      <div className="mb-20">
        <div className="mb-2 font-medium">Hình ảnh sản phẩm</div>
        <input
          type="file"
          onChange={(event) => setImages([event.target.files[0]])}
          className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
        />
      </div>
      '
      <div className="flex justify-end">
        <MilMomBtn
          content="Tạo mới"
          bg="bg-lime-300"
          className="rounded-md mr-3"
          onClick={addProduct}
        />
        <MilMomBtn
          onClick={onAbort}
          content="Hủy"
          className="rounded-md mr-3"
        />
      </div>
    </div>
  );
}
