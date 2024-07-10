import { Icon } from "@iconify/react/dist/iconify.js";
import { memo } from "react";

const Pagination = ({
  currentPage = 2,
  totalPage = 3,
  pageFunc = () => {},
}) => {
  return (
    <>
      <div className="text-center flex justify-center  items-center font-medium">
        {currentPage > 1 && (
          <div className="flex items-center">
           <div className="flex items-center mr-5" onClick={() => pageFunc(currentPage-1)}><Icon icon="ep:arrow-left" className="mr-1"/> Previous</div>
            <div className="py-3 px-4" onClick={() => pageFunc(1)}>1</div>
            <div className="px-4">...</div>
          </div>
        )}

        {currentPage > 2&&<div className="py-3 px-4" onClick={() => pageFunc(currentPage-1)}>{currentPage-1}</div>}
        <div className="py-3 px-4 border rounded-lg bg-white">{currentPage}</div>
        {currentPage < totalPage&&<><div className="px-4">...</div><div className="py-3 px-4" onClick={() => pageFunc(totalPage)}>{totalPage}</div></>}
        {currentPage < totalPage && (
          <div onClick={() => pageFunc(currentPage+1)} className="flex  items-center ml-5">
            {" "}
            Next
            <Icon icon="ep:arrow-right" className="ml-1"/>
          </div>
        )}
      </div>
    </>
  );
};

export default memo(Pagination)
