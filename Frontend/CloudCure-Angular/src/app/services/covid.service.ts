import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CovidVerify } from '../AngularModels/CovidVerify';

@Injectable({
  providedIn: 'root'
})
export class CovidService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/Covid";
  constructor(private http:HttpClient) {} 

  ////////////// Covid //////////////
  GetAll(){ 
    return this.http.get<CovidVerify[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<CovidVerify>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:CovidVerify | undefined){ 
    return this.http.post<CovidVerify>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<CovidVerify>(`${this.endpoint}/Delete/${Id}`);
  }  

  Update(Id:number| undefined, Info:CovidVerify | undefined){
    return this.http.put<CovidVerify>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
