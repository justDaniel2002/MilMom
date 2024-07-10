import axios from "axios";

export const handleUpload = async (image) => {
    const formData = new FormData();
    formData.append('file', image);
    formData.append('upload_preset', 'unsigned_preset'); // Replace with your unsigned upload preset
    formData.append('folder', 'milmomProducts'); // Specify the folder

    try {
      const response = await axios.post(
        'https://api.cloudinary.com/v1_1/dddywpfov/image/upload', // Replace with your Cloudinary cloud name
        formData
      );
      console.log(response.data.secure_url)
      return response.data.secure_url;
    } catch (error) {
      console.error('Error uploading the image:', error);
      return undefined
    }
  };