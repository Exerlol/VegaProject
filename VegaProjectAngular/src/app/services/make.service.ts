import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()
export class MakeService {
  private _baseUrl:string = "http://localhost:5000/api/";
  constructor(private _http: Http) { }

  getMakes(){
    return this._http.get(this._baseUrl + 'cars/makes').map(res => res.json());
  }
}