import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()
export class FeatureService {
  private _baseUrl:string = "http://localhost:5000/api/";
  constructor(private _http: Http) { }

  getFeatures(){
    return this._http.get(this._baseUrl + 'cars/features').map(res => res.json());
  }
}