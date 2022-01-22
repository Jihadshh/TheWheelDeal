import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarComponent } from './car/car.component';
import { CustomerComponent } from './customer/customer.component';
const routes: Routes = [
  {path:'car',component:CarComponent},
  {path:'customer',component:CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
