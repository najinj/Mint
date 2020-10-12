import axiosInstance from "../config";


export const getMachines = () =>
  axiosInstance({
    method: "GET",
    url: `Machines`
  });

export const getMachine = (id) =>
  axiosInstance({
    method: "GET",
    url: `Machine/${id}`
  }); 

export const getTotalProductions = (id) =>
  axiosInstance({
    method: "GET",
    url: `Machine/totalproduction?id=${id}`
  });

export const deleteMachine = id =>
  axiosInstance({
    method: "DELETE",
    url: `Machine/${id}`
  });