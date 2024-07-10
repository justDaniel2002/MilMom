import React from "react";
import milmom from "../../assets/milmom.png";
import { Link } from "react-router-dom";
export default function ValidEmail() {
  return (
    <div className="flex items-center min-h-screen bg-red-300 ">
      <div className="m-auto w-2/5 bg-white rounded-md px-10 py-5">
        <img src={milmom} className="m-auto mb-10 w-3/5" />
        <div className="text-2xl font-medium mb-5">Đặt lại mật khẩu</div>
        <div className="text-sm font-medium text-neutral-500 mb-5">
          Vui lòng nhập đúng email đã đăng ký tài khoản
        </div>
        <div className="mb-3">
          <div className="mb-4 ">Email</div>
          <input
            className="p-2 w-full text-neutral-500 border-2 rounded-md"
            placeholder="Email"
          />
        </div>

        <div className="mb-3">
          <div className="mb-4 ">Mật khẩu mới</div>
          <input
            className="p-2 w-full text-neutral-500 border-2 rounded-md"
            placeholder="mật khẩu mới"
          />
        </div>

        <div className="mb-5">
          <div className="mb-4 ">Nhập lại mật khẩu</div>
          <input
            className="p-2 w-full text-neutral-500 border-2 rounded-md"
            placeholder="nhập lại mật khẩu"
          />
        </div>
        <button className="w-full bg-black text-white py-2 mb-3">Đổi mật khẩu</button>
      </div>
      
      
    </div>
  );
}
