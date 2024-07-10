import React, { useEffect } from "react";
import { Outlet, useNavigate } from "react-router-dom";
import logo from "../assets/logo.png";
import { accountAtom } from "../atom/accountAtom";
import { useRecoilState } from "recoil";
export default function AuthLayout({ width = "w-1/2" }) {
  const [account, setAccount] = useRecoilState(accountAtom);

  const navigate = useNavigate();
  useEffect(() => {
    if (account?.roles.includes("Admin")) {
      navigate("/dashboard");
    }else if (account?.roles.includes("Staff")) {
      navigate("/orderManager");
    }  else if (account?.roles.includes("Manager")) {
      navigate("/productManager");
    }  else{
      navigate("/");
    }
  });
  return (
    <div className="flex">
      <div className={`${width} flex items-center bg-red-300 min-h-screen`}>
        <div>
          <img src={logo} className={`m-auto w-2/4 rounded-full mb-3`} />
          <div
            className={`text-white text-wrap ${
              width == "w-1/2" ? "px-32" : "px-10"
            } text-center text-lg`}
          >
            "Hãy bước vào thế giới tuyệt vời của mẹ và bé - đăng nhập ngay để
            tối ưu hóa mọi hoạt động và chăm sóc sức khỏe của bạn!"
          </div>
        </div>
      </div>
      <div className={width == "w-1/2" ? width : "w-2/3"}>
        <Outlet />
      </div>
    </div>
  );
}
