import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Allergy } from '../AngularModels/Allergy';

@Injectable({
  providedIn: 'root'
})
export class AllergyService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/Allergy";
  constructor(private http:HttpClient) {} 

  ////////////// Allergy //////////////


  GetAll(){ 
    return this.http.get<Allergy[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Allergy>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Allergy | undefined){ 
    return this.http.post<Allergy>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<Allergy>(`${this.endpoint}/Delete/${Id}`);
  }  

  Update(Id:number| undefined, Info:Allergy | undefined){
    return this.http.put<Allergy>(`${this.endpoint}/Update/${Id}`,Info);
  }
}
