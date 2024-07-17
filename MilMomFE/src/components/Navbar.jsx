import React, { memo } from "react";
import { blankAvatar, navbarData } from "../data/data";
import { Link, useLocation, useNavigate } from "react-router-dom";
import MilMomBtn from "./MilMomBtn";
import { Icon } from "@iconify/react/dist/iconify.js";
import logo from "../assets/logo.png";
import milmom from "../assets/milmom.png";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { toast } from "react-toastify";

const Navbar = () => {
  const [account, setAccount] = useRecoilState(accountAtom);
  const navigate = useNavigate();
  const location = useLocation();
  return (
    <div className="flex items-center">
      <div
        onClick={() => navigate("/")}
        className="w-1/6 flex items-center px-5"
      >
        <img src={logo} className="w-1/4" />
        <img src={milmom} />
      </div>
      <div className="w-3/6 flex items-center justify-evenly px-20">
        {navbarData.map((data) => (
          <Link
            to={data.link}
            className="block text-center text-wrap font-medium"
          >
            {data.content}
          </Link>
        ))}
      </div>
      <div className="w-2/6 flex items-center justify-around">
        <Icon
          onClick={() => {
            if (!account) {
              toast.warning("Đăng nhập để sử dụng giỏ hàng");
              return;
            }
            navigate("/Cart");
          }}
          icon="mdi:cart"
          className={`text-3xl ${
            location.pathname == "/Cart" && "text-red-300"
          }`}
        />
        <Icon icon="tabler:bell-ringing-2-filled" className="text-3xl" />
        {account ? (
          <>
          <Link to={"/profile"} className="block w-1/12">
            <img src={blankAvatar} className="rounded-full" />
          </Link>
           <MilMomBtn
           onClick={() => {
            localStorage.removeItem('account')
            setAccount(undefined)
            navigate("/")
           }}
           className="rounded-md"
           content="Đăng xuất"
         />
          </>
        ) : (
          <MilMomBtn
            onClick={() => navigate("/login")}
            className="rounded-md"
          />
        )}
      </div>
    </div>
  );
};

export default memo(Navbar);
