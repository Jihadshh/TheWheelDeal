import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-add-edit-cars',
  templateUrl: './add-edit-cars.component.html',
  styleUrls: ['./add-edit-cars.component.css']
})
export class AddEditCarsComponent implements OnInit {

  constructor(private service: SharedService) { }
  @Input() car: any;
  CarNumber: string | undefined;
  Make: string | undefined;
  Model: string | undefined;
  Available: string | undefined;
  addCar() {
    var val = {
      CarNumber: this.CarNumber,
      Make: this.Make,
      Model: this.Model,
      Available: this.Available
    };
    this.service.addCar(val).subscribe(res => {
      alert("Added Succs.");
    });
  }
  updateCar() {
    var val = {
      CarId: this.car.CarId,
      CarNumber: this.CarNumber,
      Make: this.Make,
      Model: this.Model,
      Available: this.Available
    };
    this.service.updateCar(val).subscribe(res => {
      alert("Updated Succs.");
    });
  }

  ngOnInit(): void {
    this.CarNumber = this.car.CarNumber;
    this.Model = this.car.Model;
    this.Available = this.car.Available;
    this.Make = this.car.Make;
  }

}
