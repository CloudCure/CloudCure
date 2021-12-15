import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Medication } from '../AngularModels/Medication';

@Injectable({
  providedIn: 'root'
})
export class MedicationService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/Medication";
  constructor(private http:HttpClient) {} 


  GetAll(){ 
    return this.http.get<Medication[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:number| undefined){
    return this.http.get<Medication>(`${this.endpoint}/Get/${Id}`);
  }
  
  Add(Info:Medication | undefined){ 
    return this.http.post<Medication>(`${this.endpoint}/Add`,Info);
  }    
  
  Delete(Id:number| undefined){ 
    return this.http.delete<Medication>(`${this.endpoint}/Delete/${Id}`);
  } 
  
  Update(Id:number| undefined, Info:Medication | undefined){
    return this.http.put<Medication>(`${this.endpoint}/Update/${Id}`,Info);
  }
}
