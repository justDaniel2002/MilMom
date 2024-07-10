import React, { useCallback, useState } from "react";
import milmomtext from "../../assets/milmomtext2.png";
import MilMomBtn from "../../components/MilMomBtn";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { postService } from "../../api/services";
import { login, register } from "../../api/apis";
import { isValidEmail } from "../../helper/helper";

export default function Register() {
  const [account, setAccount] = useState({
    username: "",
    email: "",
    name: "",
    password: "",
    address: "",
    phone: "",
  });
  const navigate = useNavigate();

  const SignUp = useCallback(() => {
    const Entries = Object.entries(account);

    for (const [key, value] of Entries) {
      if (!value || value?.trim() == "") {
        toast.warning(`${key} không được để trống`);
        return;
      }
    }

    if (account?.username?.length < 8 || account?.username?.length > 32) {
      toast.warning(`tên tài khoản phải ở trong khoảng 8 - 32 kí tự`);
      return;
    }

    if (account?.password?.length < 12 || account?.password?.length > 32) {
      toast.warning(`mật khẩu phải ở trong khoảng 12 - 32 kí tự`);
      return;
    }

    if (account?.name?.length < 8 || account?.name?.length > 32) {
      toast.warning(`họ tên phải ở trong khoảng 8 - 32 kí tự`);
      return;
    }

    if (!isValidEmail(account?.email)) {
      toast.warning(`email không hợp lệ`);
      return;
    }

    postService(register, account)
      .then(() => {
        toast.success(`Đăng kí thành công, sử dụng tài khoản mới để đăng nhập`);
        navigate(`/login`);
      })
      .catch((error) => {
        console.log(error);
        toast.error(`Đăng kí thất bại`);
        error?.response?.data?.forEach(err => toast.error(err.description))
      });
  });
  return (
    <div className="flex items-center min-h-screen">
      <div className="w-4/5 m-auto font-light">
        <img src={milmomtext} className="w-3/5 mb-20" />
        <div className="grid grid-cols-2 gap-7 mb-10">
          <div className="mb-3">
            <div className="mb-4 ">Tên Tài khoản</div>
            <input
              value={account?.username}
              onChange={(event) =>
                setAccount({ ...account, username: event.target.value })
              }
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="Nguyen Van A"
            />
          </div>

          <div className="mb-3">
            <div className="mb-4 ">Mật khẩu</div>
            <input
              value={account?.password}
              onChange={(event) =>
                setAccount({ ...account, password: event.target.value })
              }
              type="password"
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="**************"
            />
          </div>

          <div className="mb-3">
            <div className="mb-4 ">Email</div>
            <input
              value={account?.email}
              onChange={(event) =>
                setAccount({ ...account, email: event.target.value })
              }
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="info@gmail.com"
            />
          </div>

          <div className="mb-3">
            <div className="mb-4 ">Họ tên</div>
            <input
              value={account?.name}
              onChange={(event) =>
                setAccount({ ...account, name: event.target.value })
              }
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="Nguyen Van A"
            />
          </div>

          <div className="mb-3">
            <div className="mb-4 ">Địa chỉ</div>
            <input
              value={account?.address}
              onChange={(event) =>
                setAccount({ ...account, address: event.target.value })
              }
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="Địa chỉ giao hàng"
            />
          </div>

          <div className="mb-3">
            <div className="mb-4 ">Số điện thoại</div>
            <input
              value={account?.phone}
              onChange={(event) =>
                setAccount({ ...account, phone: event.target.value })
              }
              className="p-2 w-full text-neutral-500 border-2 rounded-md"
              placeholder="1234567890"
            />
          </div>
        </div>
        <div
          className="flex justify-end font-medium"
        >
          <button onClick={() => navigate("/")} className="px-5 bg-black text-white py-2 mr-5 rounded-md">
            Hủy
          </button>
          <MilMomBtn
            content="Đăng ký tài khoản"
            text="text-white"
            className="rounded-md"
            onClick={SignUp}
          />
        </div>
      </div>
    </div>
  );
}
