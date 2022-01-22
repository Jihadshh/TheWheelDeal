import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css']
})
export class AddEditCustomerComponent implements OnInit {

  constructor(private service: SharedService) { }
  @Input() customer: any;
  CustName: string | undefined;
  CustAddress: string | undefined;
  CustMobileNumber: string | undefined;
  addCustomer() {
    var val = {
      CustName: this.CustName,
      CustAddress: this.CustAddress,
      CustMobileNumber: this.CustMobileNumber
    };
    this.service.addCustomer(val).subscribe(res => {
      alert("Added Succ..");
    });
  }
  updateCustomer() {
    var val = {
      CustId: this.customer.CustId,
      CustName: this.CustName,
      CustAddress: this.CustAddress,
      CustMobileNumber: this.CustMobileNumber
    };
    this.service.updateCustomer(val).subscribe(res => {
      alert("Updated Succes..");
    });
    console.log(val);
  }

  ngOnInit(): void {
    this.CustName = this.customer.CustName;
    this.CustAddress = this.customer.CustAddress;
    this.CustMobileNumber = this.customer.CustMobileNumber;
  }

}
