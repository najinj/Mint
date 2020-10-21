import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { interval } from 'rxjs';
import { Machine } from '../models/machine.model';
import { MachineService } from '../services/machine.service';


@Component({
  selector: 'app-machine',
  templateUrl: './machine.component.html',
  styleUrls: ['./machine.component.scss']
})
export class MachineComponent implements OnInit {

  machine : Machine;
  error : HttpErrorResponse  = null;

  constructor(private machineService : MachineService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    const machineId = this.route.snapshot.params['id'];
    this.machine = new Machine(machineId);
    this.loadMachine();

    const myInterval = interval(5000);
    myInterval.subscribe(
      (value) => {
        this.loadMachine();
      },
      (err) => {
        this.error = err;
        console.log('Uh-oh, an error occurred! : ' + err);
      },
      () => {
        console.log('Observable complete!');
      }
    );
    
  }

  loadMachine () {
    this.machineService.getMachine(this.machine.machineId).subscribe(( data : Machine) =>{
      this.machine.name = data.name;
      this.machine.description = data.description;
      this.error = null;
    },
    (err : HttpErrorResponse )=>{
      this.error = err;
    });
    this.machineService.getTotalProductions(this.machine.machineId).subscribe(( data ) =>{
      this.machine.totalproduction = data.totalProdution;
      this.error = null;
    },
    (err : HttpErrorResponse )=>{
      this.error = err;
    });
  }
}
