import React from "react";
import milmom from "../../assets/milmom.png";
import { Link, useNavigate } from "react-router-dom";
export default function UnvalidEmail() {
    const navigate = useNavigate()
  return (
    <div className="flex items-center min-h-screen bg-red-300 ">
      <div className="m-auto w-2/5 bg-white rounded-md px-10 py-5">
        <img src={milmom} className="m-auto mb-10 w-3/5" />
        <div className="text-xl font-medium mb-5">
          Tài khoản email đã đăng ký không đúng
        </div>
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

        <button onClick={() => navigate("/validEmail")} className="w-full bg-black text-white py-2 mb-3">Gửi</button>
        <div className="text-center mb-3">
          <Link
            to={"/login"}
            className="text-neutral-500 underline underline-offset-4"
          >
            Quay lại màn hình đăng nhập
          </Link>
        </div>
      </div>
    </div>
  );
}
