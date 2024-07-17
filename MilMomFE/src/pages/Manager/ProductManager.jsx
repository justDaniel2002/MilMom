import React, { memo, useCallback, useEffect, useState } from "react";
import { accountList, accountType } from "../../data/data";
import MilMomBtn from "../../components/MilMomBtn";
import Pagination from "../../components/Pagination";
import ManagerTable, {
  productManagerHeader,
} from "../../components/ManagerTable";
import { deleteService, getService } from "../../api/services";
import { delProduct, getForManager, getViewProduct } from "../../api/apis";
import { objectToPram } from "../../helpers/helper";
import Modal from "react-modal";
import CreateProduct from "./CreateProduct";
import EditProduct from "./EditProduct";
import { toast } from "react-toastify";

function ProductManager() {
  const [products, setProducts] = useState([]);
  const [updateproduct, setUProduct] = useState();
  const [pageIndex, setPageIndex] = useState(1);
  const [pageSize, setPageSize] = useState(8);
  const [totalPages, setTotalPages] = useState(1);
  const [search, setSearch] = useState("");
  const [modalIsOpen, setIsOpen] = useState(false);
  const [updatemodalIsOpen, updatesetIsOpen] = useState(false);
  function openModal() {
    setIsOpen(true);
  }

  function afterOpenModal() {
    subtitle.style.color = "#f00";
  }

  function closeModal() {
    setIsOpen(false);
  }
  function updateopenModal() {
    updatesetIsOpen(true);
  }

  function updatecloseModal() {
    updatesetIsOpen(false);
  }

  const setUp = useCallback(() => {
    getService(
      `${getForManager}${objectToPram({ pageIndex, pageSize, search })}`
    ).then((result) => {
      setProducts(result.data.products);
      setTotalPages( result.data.totalPages );
    });
  }, [pageIndex, search]);

  const deleteProduct = useCallback((product) => {
    deleteService(delProduct, {}, [product?.productId]).then((res) => {
      toast.success("Đã xóa sản phẩm");
      setUp();
    });
  }, []);

  useEffect(() => {
    setUp();
  }, [search, pageIndex]);

  const nextPage = (pageIndex) => {
    setPageIndex(pageIndex)
    
  };
  return (
    <div className="py-5">
      <div className="py-5 px-20 bg-white rounded-lg min-h-screen text-sm">
        <div className="text-2xl font-medium mb-5">Quản lý sản phẩm</div>
        <div className="flex items-center justify-between mb-10">
          <div className="flex items-center w-5/6">
            <input
              value={search}
              onChange={(event) => {
                setPageIndex(1)
                setSearch(event.target.value)
              }}
              className="border rounded-md px-3 py-1 text-neutral-500 w-2/5"
              placeholder="tìm kiếm theo mã sản phâm"
            />
          </div>
          <MilMomBtn
            content="Tạo mới"
            text="text-white"
            font="font-base"
            className="rounded-lg"
            onClick={openModal}
          />
        </div>
        <ManagerTable
          approveContent="Sửa"
          deleteContent="Xóa"
          datas={products}
          headerTable={productManagerHeader}
          onApprove={(Product) => {
            setUProduct(Product);
            updateopenModal(true);
          }}
          onDelete={deleteProduct}
        />

        <div className="mt-20">
          <Pagination
            pageFunc={nextPage}
            currentPage={pageIndex}
            totalPage={totalPages}
          />
        </div>
      </div>

      <Modal
        isOpen={modalIsOpen}
        onAfterOpen={afterOpenModal}
        onRequestClose={closeModal}
        contentLabel="Thêm sản phẩm"
        className="h-4/5 overflow-y-scroll w-2/3 m-auto mt-20"
      >
        <CreateProduct onAbort={closeModal} />
      </Modal>

      <Modal
        isOpen={updatemodalIsOpen}
        onAfterOpen={afterOpenModal}
        onRequestClose={updatecloseModal}
        contentLabel="Chỉnh sửa sản phẩm"
        className="h-4/5 overflow-y-scroll w-2/3 m-auto mt-20"
      >
        <EditProduct pro={updateproduct} onAbort={updatecloseModal} />
      </Modal>
    </div>
  );
}

export default memo(ProductManager);
