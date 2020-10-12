import React, { useEffect, useState } from "react";
import { getMachines, deleteMachine} from "../api/MachineServies"
import "./styles.css"


const Home = () => {
    const [machines, SetMachines] = useState([]);
    useEffect(() => {
        const loadMachines = async () => {
            const { data } = await getMachines();
            SetMachines(data);
        }
        loadMachines();
    }, []);

    const handleClick = async (machineId) => {
       const {data,status} = await deleteMachine(machineId);
       if(data == 1 && status == 200)
         {
             const newData = machines.filter(machine => machine.machineId != machineId);
             SetMachines(newData);
         }
    }

    return (
        <div>
            <table style={{ margin: "auto",marginTop:"10%"}}>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Production</th>
                        <th> </th>
                    </tr>
                </thead>
                <tbody>
                    {machines.map(
                        machine => <>
                            <tr key={machine.machineId}>
                                <th><a href={`/${machine.machineId}`}>{machine.machineId}</a></th>
                                <th>{machine.name}</th>
                                <th>{machine.production}</th>
                                <th><button onClick={()=>handleClick(machine.machineId)}>Delete</button></th>
                            </tr>
                        </>
                    )}
                </tbody>
            </table>
        </div>
    )
}

export default Home;