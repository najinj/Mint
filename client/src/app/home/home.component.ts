import { Component, OnInit } from '@angular/core';
import { MachineService } from '../services/machine.service';
import { interval } from "rxjs";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  machines : any[] = [];
  error : boolean = false;

  constructor(private machineService : MachineService) { }

  ngOnInit(): void {
    this.machineService.getMachines().subscribe(data=>{
      this.machines = data;
      console.log(data);
    },(err)=>{
      this.error = true;
      console.log(err);
    });

    const myInterval = interval(5000);
    myInterval.subscribe(
      (value) => {
        this.machineService.getMachines().subscribe(data=>{
          this.machines = data;
          this.error = false;
        });
      },
      (err) => {
        this.error = true;
        console.log('Uh-oh, an error occurred! : ' + err);
      },
      () => {
        console.log('Observable complete!');
      }
    );
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
