import React, { useEffect, useState, useRef } from "react";
import {useParams} from "react-router-dom";
import { getMachine,getTotalProductions } from "../api/MachineServies"
import "./styles.css"




const Machine = () => {
    const [machine, SetMachine] = useState({name:"",description:"",totalproduction : 0});
    const { id } = useParams();

    useEffect(() => {
        const loadMachines = async () => {
            const { data } = await getMachine(id);
            const res = await getTotalProductions(id);
            SetMachine({
                name : data.name,
                description : data.description,
                totalproduction  : res.data.totalProdution
            });
        }
        loadMachines();
    }, []);

    const useInterval = (callback, delay) => {
        const savedCallback = useRef();
      
        useEffect(() => {
          savedCallback.current = callback;
        }, [callback]);
      
        useEffect(() => {
          function tick() {
            savedCallback.current();
          }
          if (delay !== null) {
            let id = setInterval(tick, delay);
            return () => clearInterval(id);
          }
        }, [delay]);
    }

    useInterval(async() => {
        const { data } = await getMachine(id);
        const res = await getTotalProductions(id);
        SetMachine({
            name : data.name,
            description : data.description,
            totalproduction  : res.data.totalProdution
        });
    }, 5000);

    return (
        <div>
            <table style={{ margin: "auto",marginTop:"10%"}}>
                <tr>
                    <td>Machine</td>
                    <td>{machine.name}</td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>{machine.description}</td>
                </tr>
                <tr>
                    <td>Total production</td>
                    <td>{machine.totalproduction}</td>
                </tr>
            </table>
        </div>
    )
}

export default Machine;