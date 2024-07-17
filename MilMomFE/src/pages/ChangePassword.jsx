import React, { useState } from "react";
import MilMomBtn from "../components/MilMomBtn";
import { toast } from "react-toastify";
import { changePassword } from "../api/apis";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";

export default function ChangePassword() {
  const [oldpass, setOldpass] = useState("");
  const [newpass, setNewpass] = useState("");
  const [confirmpass, setConfirm] = useState("");
  const [account, setAccount] = useRecoilState(accountAtom);

  const submit = () => {
    if (oldpass.trim() == "") {
      toast.warning("Nhập mật khẩu cũ");
      return;
    }

    if (newpass.trim() == "") {
      toast.warning("Nhập mật khẩu mới");
      return;
    }

    if (newpass != confirmpass) {
      toast.warning("Mật khẩu mới và mật khẩu xác nhận không trùng khớp");
      return;
    }

    postService(changePassword, {
      userName: account?.userName,
      currentPassword: oldpass,
      newPassword: newpass,
      confirmNewPassword: confirmpass,
    })
      .then(() => {
        toast.success(`Thay đổi mật khẩu thành công`);
        localStorage.removeItem("account");
        setAccount(undefined);
        navigate(`/login`);
      })
      .catch((error) => {
        console.log(error);
        toast.error(`Thay đổi mật khẩu thất bại`);
        error?.response?.data?.forEach((err) => toast.error(err.description));
      });
  };
  return (
    <div className="px-40">
      <div className="font-bold text-3xl">Thay đổi mật khẩu</div>
      <div className="font-medium text-lg my-5">
        Để bảo mật tài khoản, vui lòng không chia sẻ mật khẩu cho người khác
      </div>

      <div className="px-40 font-medium">
        <div className="bg-white rounded-md p-3 mb-5">
          <div className="mb-5 text-lg">Mật khẩu cũ</div>
          <input
            value={oldpass}
            onChange={(event) => setOldpass(event.target.value)}
            type="password"
            className="p-3 rounded-md w-full border border-neutral-500"
          />
        </div>
        <div className="bg-white rounded-md p-3 mb-5">
          <div className="mb-5 text-lg">Mật khẩu mới</div>
          <input
            value={newpass}
            onChange={(event) => setNewpass(event.target.value)}
            type="password"
            className="p-3 rounded-md w-full border border-neutral-500"
          />
        </div>
        <div className="bg-white rounded-md p-3 mb-5">
          <div className="mb-5 text-lg">Xác nhận lại mật khẩu mới</div>
          <input
            value={confirmpass}
            onChange={(event) => setConfirm(event.target.value)}
            type="password"
            className="p-3 rounded-md w-full border border-neutral-500"
          />
        </div>

        <div className="flex justify-end">
          <MilMomBtn className="rounded-md" content="Lưu" />
        </div>
      </div>
    </div>
  );
}
