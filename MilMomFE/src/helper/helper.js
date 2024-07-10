import axios from "axios";
import { toast } from "react-toastify";

export function isValidEmail(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
}

export const getAccountFS = () => {
  const account = localStorage.getItem(`account`);
  if (account) {
    try {
      const accJson = JSON.parse(account);
      if (accJson?.userName) return accJson;
    } catch (error) {
      console.log(error);
    }
  }
  return undefined;
};

export const getProvines = async () => {
  const provinesRaw = await axios.get(
    "https://esgoo.net/api-tinhthanh/4/0.htm"
  );
  return provinesRaw.data.data;
};

export function convertToCustomFormat(isoString) {
  if(!isoString) return 
  // Parse the ISO 8601 date-time string
  const date = new Date(isoString);

  // Extract the components
  const day = String(date.getDate()).padStart(2, "0");
  const month = String(date.getMonth() + 1).padStart(2, "0"); // Months are zero-indexed
  const year = date.getFullYear();
  const hours = String(date.getHours()).padStart(2, "0");
  const minutes = String(date.getMinutes()).padStart(2, "0");

  // Format the components into the desired format
  const formattedDate = `${day}/${month}/${year} ${hours}:${minutes}`;

  return formattedDate;
}

export function convertDateFormat(ioDateStr) {
  if(!ioDateStr) return
  // Extract the date part from the IO format string
  const datePart = ioDateStr.split("T")[0];

  return datePart;
}

export function convertToIOFormat(dateStr) {
  // Replace '/' with '-' to match the IO date part format
  const datePart = dateStr.replace(/\//g, '-');

  // Get the current time in 'HH:MM:SS.sss' format
  const now = new Date();
  const timePart = now.toISOString().split('T')[1];

  // Construct the full IO format string
  const ioFormat = `${datePart}T${timePart}`;

  return ioFormat;
}

// Example usage:
const dateStr = '2024/07/10';
const ioFormat = convertToIOFormat(dateStr);
console.log(ioFormat);  // Output: 202


export function getCurrentDate() {
  const today = new Date();
  const day = String(today.getDate()).padStart(2, "0");
  const month = String(today.getMonth() + 1).padStart(2, "0"); // Months are zero-based
  const year = today.getFullYear();

  return `${day}/${month}/${year}`;
}

export function generateUUID() {
  return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}


export function validateProduct(product){
    if(product?.name==undefined||!product?.name?.length>0){
        toast.warning("Điền tên sản phẩm")
        return false;
    }

    if(product?.inventoryQuantity==undefined||!product?.inventoryQuantity>0){
        toast.warning("Số lượng trong kho lớn hơn 0")
        return false;
    }

    if(product?.description==undefined||!product?.description?.length>0){
        toast.warning("Điền mô tả sản phẩm")
        return false;
    }

    if(product?.unitPrice==undefined||!product?.unitPrice>0){
        toast.warning("Giá nhập hàng lớn hơn 0")
        return false;
    }

    if(product?.purchasePrice==undefined||!product?.purchasePrice>0){
        toast.warning("Giá mua lớn hơn 0")
        return false;
    }

    if(product?.supplier==undefined||!product?.supplier?.length>0){
        toast.warning("Điền nhãn hàng")
        return false;
    }

    if(product?.expiredDate==undefined||!product?.expiredDate?.length>0){
        toast.warning("Điền ngày hết hạn sản phẩm")
        return false;
    }

    if(product?.original==undefined||!product?.original?.length>0){
      toast.warning("Điền xuất xứ sản phẩm")
      return false;
  }

    if(product?.ingredient==undefined||!product?.ingredient?.length>0){
        toast.warning("Điền thành phần sản phẩm")
        return false;
    }

    if(product?.instruction==undefined||!product?.instruction?.length>0){
        toast.warning("Điền hướng dẫn sử dụng")
        return false;
    }

    if(product?.weight==undefined||!product?.weight>0){
        toast.warning("Trọng lượng ít nhất 1 (g)")
        return false;
    }

    if(product?.height==undefined||!product?.height>0){
        toast.warning("Chiều cao ít nhất 1 cm")
        return false;
    }

    if(product?.width==undefined||!product?.width>0){
        toast.warning("Chiều rộng ít nhất 1 cm")
        return false;
    }
    return true;
}