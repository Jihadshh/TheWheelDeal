import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-customers',
  templateUrl: './show-customers.component.html',
  styleUrls: ['./show-customers.component.css']
})
export class ShowCustomersComponent implements OnInit {

  constructor(private service: SharedService) { }

  CustomerList: any = [];
  ModalTitle: string | undefined;
  ActivateAddEditCustomerComp: boolean = false;
  customer: any;

  ngOnInit(): void {
    this.refreshCustomerList();
  }
  addClick() {
    this.customer = {
      CustId: 0,
      CustName: "",
      CustAddress: "",
      CustMobileNumber: "",
    }
    this.ModalTitle = "Add Customer";
    this.ActivateAddEditCustomerComp = true;
  }
  deleteClick(item: any) {
    if(confirm('Are you sure??')){
      this.service.DeleteCustomer(item.CustId).subscribe(data=>
        {
          alert("Deleted Succ..");
          this.refreshCustomerList();
        })
    }
  }
  editClick(item: any) {
    this.customer = item;
    this.ModalTitle = "Edit Customer";
    this.ActivateAddEditCustomerComp = true;
  }
  closeClick() {
    this.ActivateAddEditCustomerComp = false;
    this.refreshCustomerList;
  }
  refreshCustomerList() {
    this.service.getCustomerList().subscribe(data => {
      this.CustomerList = data;
    });
  }
}
