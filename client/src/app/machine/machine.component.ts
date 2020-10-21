import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Machine } from '../models/machine.model';
import { MachineService } from '../services/machine.service';

@Component({
  selector: 'app-machine',
  templateUrl: './machine.component.html',
  styleUrls: ['./machine.component.scss']
})
export class MachineComponent implements OnInit {

  machine : Machine;
  

  constructor(private machineService : MachineService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    
    const machineId = this.route.snapshot.params['id'];
    this.machine = new Machine(machineId);
    this.machineService.getMachine(this.machine.machineId).subscribe(( data : Machine) =>{
      this.machine.name = data.name;
      this.machine.description = data.description;
    });
    this.machineService.getTotalProductions(this.machine.machineId).subscribe(( data ) =>{
      this.machine.totalproduction = data.totalProdution;
    });
  }
}
