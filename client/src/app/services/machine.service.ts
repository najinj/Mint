
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Machine } from '../models/machine.model';

@Injectable()
export class MachineService {

    baseUrl : string = "https://localhost:44391";

    constructor(private http : HttpClient){}

    getMachines() {
        return this.http.get<Machine[]>(`${this.baseUrl}/Machines`);
    }

    getMachine(machineId : number) {
        return this.http.get<Machine>(`${this.baseUrl}/Machine/${machineId}`);
    }

    getTotalProductions(machineId : number) {
        return this.http.get<any>(`${this.baseUrl}/Machine/totalproduction?id=${machineId}`);
    }

    deleteMachine(machineId : number) {
        return this.http.delete<number>(`${this.baseUrl}/Machine/${machineId}`);
    }
}