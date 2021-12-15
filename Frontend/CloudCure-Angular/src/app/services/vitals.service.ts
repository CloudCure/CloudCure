import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vitals } from '../AngularModels/Vitals';

@Injectable({
  providedIn: 'root'
})
export class VitalsService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(public http:HttpClient) { }

  ////////////// Vitals //////////////
  GetAll() 
  { 
    //this route will need to match route on API controller
    return this.http.get<Vitals[]>(`${this.endpoint}/api/Vitals/All`);
  }

  GetById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<Vitals>(`${this.endpoint}/api/Vitals/${Id}`);
  }

  Add(Info:Vitals | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<Vitals>(`${this.endpoint}/api/Vitals/Add`,Info);
  }  

  update(Info:Vitals | undefined, Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.put<Vitals>(`${this.endpoint}/api/Vitals/update/${Id}`,Info);
  } 

  Delete(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<Vitals>(`${this.endpoint}/api/Vitals/delete/${Id}`);
  } 

}
