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
  GetAllCovidInfo(){ 
    return this.http.get<CovidVerify[]>(`${this.endpoint}/Get/All`);
  }

  GetCovidInfoById(Id:Number | undefined){ 
    return this.http.get<CovidVerify>(`${this.endpoint}/Get/${Id}`);
  }

  AddCovidInfo(Info:CovidVerify | undefined){ 
    return this.http.post<CovidVerify>(`${this.endpoint}/Add`,Info);
  }  

  DeleteCovidInfo(Id:number| undefined){ 
    return this.http.delete<CovidVerify>(`${this.endpoint}/Delete/${Id}`);
  }  

  UpdateCovidInfo(Id:number| undefined, Info:CovidVerify | undefined){
    return this.http.put<CovidVerify>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
