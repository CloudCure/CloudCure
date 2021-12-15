import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CovidVerify } from '../AngularModels/CovidVerify';

@Injectable({
  providedIn: 'root'
})
export class CovidService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(private http:HttpClient) {} 

  ////////////// Covid //////////////
  GetAllCovidInfo() 
  { 
    //this route will need to match route on API controller
    return this.http.get<CovidVerify[]>(`${this.endpoint}/Covid/GetAll`);
  }

  GetCovidInfoById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<CovidVerify>(`${this.endpoint}/Covid/Get/${Id}`);
  }

  AddCovidInfo(Info:CovidVerify | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<CovidVerify>(`${this.endpoint}/Covid/Add`,Info);
  }  

  DeleteCovidInfo(Id:number| undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<CovidVerify>(`${this.endpoint}/Covid/Delete/${Id}`);
  }  
}
