import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MachineService } from './services/machine.service';
import { HttpClientModule } from '@angular/common/http';
import { FourOfFourComponent } from './four-of-four/four-of-four.component';
import { MachineComponent } from './machine/machine.component';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'machine/:id', component: MachineComponent },
  { path: '**', component: FourOfFourComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FourOfFourComponent,
    MachineComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    MachineService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
