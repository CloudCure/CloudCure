import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Surgery } from '../AngularModels/Surgery';

@Injectable({
  providedIn: 'root'
})
export class SurgeryService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Surgery";
  constructor(private http:HttpClient) { }

  ////////////// Surgery //////////////
  GetAll(){ 
    return this.http.get<Surgery[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:number| undefined){
    return this.http.get<Surgery>(`${this.endpoint}/Get/${Id}`);
  }
  
  Add(Info:Surgery | undefined){ 
    return this.http.post<Surgery>(`${this.endpoint}/Add`,Info);
  }    
  
  Delete(Id:number| undefined){ 
    return this.http.delete<Surgery>(`${this.endpoint}/Delete/${Id}`);
  } 
  
  Update(Id:number| undefined, Info:Surgery | undefined){
    return this.http.put<Surgery>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
