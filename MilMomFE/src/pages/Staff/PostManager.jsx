import React from "react";
import MilMomBtn from "../../components/MilMomBtn";
import { Icon } from "@iconify/react/dist/iconify.js";
import Pagination from "../../components/Pagination";

export default function PostManager() {
  return (
    <div className="bg-red-100 px-10 py-10">
      <div className="text-3xl font-medium mb-5">Quản lý bài viết</div>
      <div className="flex items-center mb-3">
        <input
          placeholder="Tìm kiếm theo bài viết"
          className="rounded-md p-3 w-1/5"
        />
        <MilMomBtn
          content="Tạo bài viết mới"
          text="text-white"
          className="rounded-md"
        />
      </div>

      <div className="border border-black">
        <div className="px-5 pt-10 text-xl font-medium bg-red-200 ">
          <div className="mb-10">
            Tên bài viết: Dinh dưỡng cho mẹ trong những tháng đầu tiên
          </div>
          <div className="flex justify-end text-sm">Ngày đăng: 28/6/2024</div>
        </div>
        <div className="bg-white p-5">
            <div className="text-red-100 mb-2">Nội dung bài viết</div>
        </div>
        <div className="bg-white p-5">
            <div className="text-red-100 mb-2">Hình ảnh đính kèm</div>

            <div className="flex justify-end text-red-100 bg-red-300 p-3 rounded-full"><Icon icon="material-symbols:edit" /></div>
        </div>
      </div>

      <Pagination />
    </div>
  );
}
