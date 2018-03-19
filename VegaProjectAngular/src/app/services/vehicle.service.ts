import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()
export class VehicleService {

  private _baseUrl:string = "http://localhost:5000/api/";
  constructor(private _http: Http) { }
  
  getMakes(){
    return this._http.get(this._baseUrl + 'cars/makes').map(res => res.json());
  }
  getFeatures(){
    return this._http.get(this._baseUrl + 'cars/features').map(res => res.json());
  }

  getVehicle(id: number) {
    return this._http.get(this._baseUrl + 'vehicle/get/' + id).map(res => res.json());
  }

}