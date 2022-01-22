import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="https://localhost:44330/api";

constructor(private http:HttpClient) { }
getCustomerList():Observable<any[]>{
  return this.http.get<any>(this.APIUrl+'/Customer')
}
addCustomer(val:any){
  return this.http.post(this.APIUrl+'/Customer', val)
}
updateCustomer(val:any){
  return this.http.put(this.APIUrl+'/Customer',val)
}
DeleteCustomer(val:any){
  return this.http.delete(this.APIUrl+'/Customer/'+val)
}
getCarList():Observable<any[]>{
  return this.http.get<any>(this.APIUrl+'/Car')
}
addCar(val:any){
  return this.http.post(this.APIUrl+'/Car',val)
}
updateCar(val:any){
  return this.http.put(this.APIUrl+'/Car',val)
}
DeleteCar(val:any){
  return this.http.delete(this.APIUrl+'/Car/'+val)
}
}
