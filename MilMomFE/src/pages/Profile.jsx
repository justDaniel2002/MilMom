import React, { useCallback, useEffect, useState } from "react";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { getService, putService } from "../api/services";
import { getUserInfo, updateAccount } from "../api/apis";

export default function Profile() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [userInfo, setUserInfo] = useState();
  useEffect(() => {
    getService(getUserInfo, [account?.userID]).then((result) => {
      setUserInfo(result.data);
      console.log("user info", result);
    });
  },[]);

  
  return (
    <div>
      <div className="font-bold text-3xl">Thông tin hồ sơ cá nhân</div>
      <div className="font-medium text-lg my-5">
        Quản lý thông tin cá nhân của bạn, bao gồm họ tên, số điện thoại, địa
        chỉ và email của bạn
      </div>
      <div className="mt-20 grid font-medium  grid-cols-2 gap-5">
        <div className="bg-white rounded-md border-2 border-neutral-500 p-3">
          <div className="mb-5 text-xl">Họ và tên</div>
          <div>{userInfo?.name}</div>
        </div>

        <div className="bg-white rounded-md border-2 border-neutral-500 p-3">
          <div className="mb-5 text-xl">Địa chỉ</div>
          <div>{userInfo?.address}</div>
        </div>

        <div className="bg-white rounded-md border-2 border-neutral-500 p-3">
          <div className="mb-5 text-xl">Số điện thoại</div>
          <div>{userInfo?.phone}</div>
        </div>

        <div className="bg-white rounded-md border-2 border-neutral-500 p-3">
          <div className="mb-5 text-xl">Email</div>
          <div>{userInfo?.email}</div>
        </div>
      </div>
    </div>
  );
}
