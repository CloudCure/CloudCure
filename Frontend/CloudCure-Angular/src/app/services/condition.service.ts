import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Condition } from '../AngularModels/Condition';

@Injectable({
  providedIn: 'root'
})
export class ConditionService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Condition";
  constructor(private http:HttpClient) {} 

  GetAll(){ 
    return this.http.get<Condition[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Condition>(`${this.endpoint}/Get/${Id}`);
  }

  SearchByPatientId(Id:Number | undefined){ 
    return this.http.get<Condition>(`${this.endpoint}/Get/Patient${Id}`);
  }

  Add(Info:Condition | undefined){ 
    return this.http.post<Condition>(`${this.endpoint}/Add`,Info);
  }  

   Update(Id:number| undefined, Info:Condition| undefined){
    return this.http.put<Condition>(`${this.endpoint}/Update/${Id}`,Info);
  }

  Delete(Id:number| undefined){ 
    return this.http.delete<Condition>(`${this.endpoint}/Delete/${Id}`);
  } 
}
