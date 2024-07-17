import React, { useCallback, useEffect, useState } from "react";
import { emptyAvatar } from "../data/data";
import MilMomBtn from "../components/MilMomBtn";
import { useRecoilState } from "recoil";
import { accountAtom } from "../atom/accountAtom";
import { getService, putService } from "../api/services";
import { getUserInfo, updateAccount } from "../api/apis";
import { name } from "@cloudinary/url-gen/actions/namedTransformation";
import { handleUpload } from "../cloudinary/cloudinary";
import { toast } from "react-toastify";

export default function ProfileEdit() {
  const [account, setAccount] = useRecoilState(accountAtom);
  const [userInfo, setUserInfo] = useState();
  const [image, setImage] = useState();
  useEffect(() => {
    getService(getUserInfo, [account?.userID]).then((res) =>
      setUserInfo(res.data)
    );
  }, []);

  const update = useCallback(async () => {
    if (image) {
      const imgurl = await handleUpload(image);
      setUserInfo({ ...userInfo, image: imgurl });
    }
    putService(
      `${updateAccount}?userId=${account.userID}`,
      {
        username: userInfo.userName,
        address: userInfo.address,
        phone: userInfo.phone,
        email: userInfo.email,
        image: userInfo.image,
        name: userInfo.name
      },
    ).then((res) => {
      toast.success("Cập nhập hồ sơ thành công");
      setAccount({
        ...account,
        name: userInfo?.name,
        phone: userInfo?.phone,
        address: userInfo?.address,
        email: userInfo?.email,
      });
    });
  }, [userInfo, image]);
  return (
    <div>
      <div className="font-bold text-3xl">Chỉnh sửa hồ sơ cá nhân</div>
      <div className="font-medium text-lg my-5">
        Chỉnh sửa thông tin cá nhân của bạn, bao gồm họ tên, số điện thoại, địa
        chỉ, email và hình ảnh của bạn
      </div>

      <div className="flex mt-10 font-medium">
        <div className="w-1/3 pr-5 border-r border-neutral-400">
          <div className="bg-white rounded-md p-3 mb-5">
            <div className="mb-5 text-lg">Tên đăng nhập</div>
            <div>{userInfo?.userName}</div>
          </div>

          <div className="bg-white rounded-md p-3 mb-5">
            <div className="mb-5 text-lg">Họ và tên</div>
            <input
              onChange={(event) =>
                setUserInfo({ ...userInfo, name: event.target.value })
              }
              className="p-3 rounded-md w-full border border-neutral-500"
              value={userInfo?.name}
            />
          </div>

          <div className="bg-white rounded-md p-3 mb-5">
            <div className="mb-5 text-lg">Số điện thoại</div>
            <input
              onChange={(event) =>
                setUserInfo({ ...userInfo, phone: event.target.value })
              }
              className="p-3 rounded-md w-full border border-neutral-500"
              value={userInfo?.phone}
            />
          </div>

          <div className="bg-white rounded-md p-3 mb-5">
            <div className="mb-5 text-lg">Địa chỉ</div>
            <input
              onChange={(event) =>
                setUserInfo({ ...userInfo, address: event.target.value })
              }
              className="p-3 rounded-md w-full border border-neutral-500"
              value={userInfo?.address}
            />
          </div>

          <div className="bg-white rounded-md p-3 mb-5">
            <div className="mb-5 text-lg">Email</div>
            <input
              onChange={(event) =>
                setUserInfo({ ...userInfo, email: event.target.value })
              }
              className="p-3 rounded-md w-full border border-neutral-500"
              value={userInfo?.email}
            />
          </div>

          <div className="flex justify-end">
            <MilMomBtn onClick={update} content="Lưu" />
          </div>
        </div>

        <div className="w-2/3 flex justify-center items-center">
          <div>
            <img className="rounded-full" src={userInfo?.image ?? emptyAvatar} />
            <input
              onChange={(event) => setImage(event.target?.files[0])}
              id="imageInput"
              type="file"
              hidden
            />
            <MilMomBtn
              onClick={() => {
                document.getElementById("imageInput").click();
              }}
              className="mt-5"
              content="Tạo ảnh"
              bg="bg-white"
            />
          </div>
        </div>
      </div>
    </div>
  );
}
