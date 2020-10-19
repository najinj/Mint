import axios from "axios";


const axiosInstance = axios.create({
  baseURL: "https://localhost:44391/", 
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

export default axiosInstance;