import axios from "axios";

export const instance = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
});

export const setAuthToken = (token) => {
  if (token) {
    instance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
  } else {
    delete instance.defaults.headers.common['Authorization'];
  }
}
