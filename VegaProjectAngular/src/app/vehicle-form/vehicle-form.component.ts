import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';

import { Make, Model,Feature } from '../Interfaces/Interfaces';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  id:number = 0;
  vehicle:any = {};
  makes:Make[] = [];
  models:Model[] = [];
  features:Feature[] = [];
  checkedFeatures: number[] = [];

  constructor(private _vehicleService:VehicleService,private _route:ActivatedRoute) {
         this.id = this._route.snapshot.params['id'];
  }
  isChecked(feature:Feature){
    return false;
    // if(this.vehicle.features)
    //     this.vehicle.features.findIndex((f:any) => f.id === feature.id) > -1;
  }
  updateChecked(feature:Feature, event:any) {
    this.checkedFeatures.push(feature.id);
  }
  booleanFunction(feature:Feature){
    return true;
  }

  ngOnInit() {
    this._vehicleService.getMakes().subscribe(makes => {
      this.makes = makes;
    });
    this._vehicleService.getFeatures().subscribe(features => {
      this.features = features;
    });

    if(this.id > 0){
        this._vehicleService.getVehicle(this.id).subscribe(vehicle => {
          this.vehicle = vehicle;
          this.models = this.makes.filter(m => m.id == vehicle.make.id)[0].models;
      });
    }
  }

  makeChanged(makeId:number){
    makeId ? this.models = this.makes.filter(m => m.id == makeId)[0].models : this.models = []
  }

  submit(form: any){
    form["features"] = this.checkedFeatures;
    delete form['make'];
    console.log(form);
    
  }
}