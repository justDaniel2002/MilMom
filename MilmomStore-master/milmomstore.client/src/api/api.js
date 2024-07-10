import axios from "axios";

const baseUrl = axios.create({
  baseURL: "https://localhost:5262",
});

export default baseUrl;