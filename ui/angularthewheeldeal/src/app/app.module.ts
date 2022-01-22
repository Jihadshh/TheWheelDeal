import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { ShowCustomersComponent } from './customer/show-customers/show-customers.component';
import { AddEditCustomerComponent } from './customer/add-edit-customer/add-edit-customer.component';
import { CarComponent } from './car/car.component';
import { ShowCarsComponent } from './car/show-cars/show-cars.component';
import { AddEditCarsComponent } from './car/add-edit-cars/add-edit-cars.component';
import { SharedService } from './shared.service';
import{HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ShowCustomersComponent,
    AddEditCustomerComponent,
    CarComponent,
    ShowCarsComponent,
    AddEditCarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
