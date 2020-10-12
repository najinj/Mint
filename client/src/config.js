import axios from "axios";


const axiosInstance = axios.create({
  baseURL: "https://localhost:44391/", 
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

axiosInstance.interceptors.request.use(
  config => {
    // Do something before request is sent
    return config;
  },
  error => {
    // Do something with request error
    return Promise.reject(error);
  }
);

// Add a response interceptor
axiosInstance.interceptors.response.use(
  response => {
    console.log("axiosInstance");
    // Do something with response data
    return response;
  },
  error => {
    switch (error.response.status) {
      case 401:
        break;
      default:
        break;
    }
    // Do something with response error
    return Promise.reject(error);
  }
);

export default axiosInstance;