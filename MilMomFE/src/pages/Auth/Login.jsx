import React, { useCallback, useState } from "react";
import milmomtext from "../../assets/milmomtext.png";
import MilMomBtn from "../../components/MilMomBtn";
import { Link, useNavigate } from "react-router-dom";
import { postService } from "../../api/services";
import { login } from "../../api/apis";
import { useRecoilState } from "recoil";
import { accountAtom } from "../../atom/accountAtom";
import { toast } from "react-toastify";
export default function Login() {
  const [accountA, setAccountAtom] = useRecoilState(accountAtom)
  const [account, setAccount] = useState({
    username: "",
    password: "",
  });

  const navigate = useNavigate()

  const SignIn = useCallback(() => {
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

    postService(login, account).then(result => {
      toast.success('Đăng nhập thành công')
      localStorage.setItem('account', JSON.stringify(result))
      setAccountAtom(result)
    }).catch((error) => {
      console.log(error)
      toast.error("Đăng nhập thất bại")
      toast.error(error?.response?.data)
    })
  })
  return (
    <div className="flex items-center min-h-screen">
      <div className="w-2/3 m-auto">
        <img className="w-full mb-2" src={milmomtext} />
        <div className="font-medium text-neutral-500 text-sm mb-5">
          Đăng nhập để trải nghiệm đầy đủ dịch vụ và thông tin hơn
        </div>

        <div className="mb-3">
          <div className="mb-2 font-medium">Tên người dùng</div>
          <input
            value={account?.username}
            onChange={(event) =>
              setAccount({ ...account, username: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
            placeholder="Tên người dùng"
          />
        </div>

        <div className="mb-20">
          <div className="mb-2 font-medium">Mật khẩu</div>
          <input
            value={account?.password}
            onChange={(event) =>
              setAccount({ ...account, password: event.target.value })
            }
            className="p-2 w-4/5 text-neutral-500 border-2 rounded-md"
            type="password"
            placeholder="**************"
          />
        </div>

        <button onClick={SignIn} className="w-4/5 bg-black text-white py-2 mb-3">
          Đăng nhập
        </button>
        <MilMomBtn onClick={() => navigate('/register')} content="Đăng ký" className="w-4/5 mb-5" />
        <div className="text-center w-4/5 mb-3">
          <Link
            to={"/forgotPassword"}
            className="text-neutral-500 underline underline-offset-4"
          >
            Bạn quên mật khẩu ?
          </Link>
        </div>

        <div className="text-center w-4/5 mb-3">
          <Link to={"/register"} className="text-neutral-500">
            Bạn chưa có tài khoản ?{" "}
            <span className="text-red-300 font-medium">Đăng ký ngay</span>
          </Link>
        </div>
      </div>
    </div>
  );
}
