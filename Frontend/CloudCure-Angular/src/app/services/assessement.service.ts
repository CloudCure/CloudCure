import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Assessment } from '../AngularModels/Assessment';

@Injectable({
  providedIn: 'root'
})
export class AssessmentService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Assessment";
  constructor(private http:HttpClient) {} 

  ////////////// Assessment //////////////
  GetAll(){ 
    return this.http.get<Assessment[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Assessment>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Assessment | undefined){ 
    return this.http.post<Assessment>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<Assessment>(`${this.endpoint}/Delete/${Id}`);
  }  

  Update(Id:number| undefined, Info:Assessment | undefined){
    return this.http.put<Assessment>(`${this.endpoint}/Update/${Id}`,Info);
  }

}

