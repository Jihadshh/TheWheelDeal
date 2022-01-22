import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-cars',
  templateUrl: './show-cars.component.html',
  styleUrls: ['./show-cars.component.css']
})
export class ShowCarsComponent implements OnInit {

  constructor(private service: SharedService) { }

  CarList: any = [];
  ModalTitle: string | undefined;
  ActivateAddEditCarComp: boolean = false;
  car: any;

  ngOnInit(): void {
    this.refreshCarList();
  }
  addClick() {
    this.car = {
      CarId: 0,
      CarNumber: "",
      Make: "",
      Available: "",
    }
    this.ModalTitle = "Add Car";
    this.ActivateAddEditCarComp = true;
  }
  deleteClick(item: any) {
    if(confirm('Are you sure??')){
      this.service.DeleteCar(item.CarId).subscribe(data=>
        {
          alert("Deleted Succs.");
          this.refreshCarList();
        })
    }
  }
  editClick(item: any) {
    this.car = item;
    this.ModalTitle = "Edit Car";
    this.ActivateAddEditCarComp = true;
  }
  closeClick() {
    this.ActivateAddEditCarComp = false;
    this.refreshCarList;
  }
  refreshCarList() {
    this.service.getCarList().subscribe(data => {
      this.CarList = data;
    });
  }
}
