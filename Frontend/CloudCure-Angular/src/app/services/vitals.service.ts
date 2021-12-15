import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vitals } from '../AngularModels/Vitals';

@Injectable({
  providedIn: 'root'
})
export class VitalsService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/Vitals";
  constructor(public http:HttpClient) { }

  ////////////// Vitals //////////////
  GetAll(){
    return this.http.get<Vitals[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){
    return this.http.get<Vitals>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Vitals | undefined){
    return this.http.post<Vitals>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number | undefined){ 
    return this.http.delete<Vitals>(`${this.endpoint}/Delete/${Id}`);
  } 

  Update(Info:Vitals | undefined, Id:Number | undefined){
    return this.http.put<Vitals>(`${this.endpoint}/Update/${Id}`,Info);
  } 

  

}
