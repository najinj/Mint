import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Machine } from '../models/machine.model';
import { MachineService } from '../services/machine.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  machines : Machine[] = [];
  error : HttpErrorResponse  = null;
  loading : boolean = true;

  constructor(private machineService : MachineService) { }

  ngOnInit(): void {
    this.machineService.getMachines().subscribe((data : Machine[])=>{
      this.machines = data;
      this.error = null;
      this.loading = false;
    },(err : HttpErrorResponse)=>{
      this.error = err;
      this.loading = false;
      console.log(err);
    });
  }

  deleteMachine(machineId : number) : void {
    if(confirm('Are you sure you want to delete this machine ?')) {
      this.machineService.deleteMachine(machineId).subscribe(data=>{
        if(data == 1){
          this.machines = this.machines.filter(machine=>machine.machineId != machineId);
        }
      });
    }
  }
}
