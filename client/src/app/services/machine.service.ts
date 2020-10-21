
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Machine } from '../models/machine.model';
import {environment} from "../../environments/environment";

@Injectable()
export class MachineService {

    constructor(private http : HttpClient){}

    getMachines() {
        return this.http.get<Machine[]>(`${environment.baseUrl}/Machines`);
    }

    getMachine(machineId : number) {
        return this.http.get<Machine>(`${environment.baseUrl}/Machine/${machineId}`);
    }

    getTotalProductions(machineId : number) {
        return this.http.get<any>(`${environment.baseUrl}/Machine/totalproduction?id=${machineId}`);
    }

    deleteMachine(machineId : number) {
        return this.http.delete<number>(`${environment.baseUrl}/Machine/${machineId}`);
    }
}