import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Allergy } from '../AngularModels/Allergy';
import { Condition } from '../AngularModels/Condition';
import { Medication } from '../AngularModels/Medication';
import { Patient } from '../AngularModels/Patient';
import { Surgery } from '../AngularModels/Surgery';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/Patient";
  constructor(private http:HttpClient) {} 

  ////////////// Patient //////////////
  GetAll(){ 
    return this.http.get<Patient[]>(`${this.endpoint}/Get/All`);
  }

  GetAllAllergies(){ 
    return this.http.get<Allergy[]>(`${this.endpoint}/Get/All/Allergies`);
  }

  GetAllConditions(){ 
    return this.http.get<Condition[]>(`${this.endpoint}/Get/All/Conditions`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Patient>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Patient | undefined){ 
    return this.http.post<Patient>(`${this.endpoint}/Add`,Info);
  }  

  AddAllergy(Info:Allergy | undefined){ 
    return this.http.post<Allergy>(`${this.endpoint}/Add/Allergy`,Info);
  }  

  AddCondition(Info:Condition | undefined){ 
    return this.http.post<Condition>(`${this.endpoint}/Add/Condition`,Info);
  }  



  AddSurgery(Info:Surgery | undefined){ 
    return this.http.post<Surgery>(`${this.endpoint}/Add/Surgery`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<Patient>(`${this.endpoint}/Delete/${Id}`);
  }  

  DeleteAllergy(Id:number| undefined){ 
    return this.http.delete<Allergy>(`${this.endpoint}/Delete/Allergy/${Id}`);
  } 

  DeleteCondition(Id:number| undefined){ 
    return this.http.delete<Condition>(`${this.endpoint}/Delete/Condition/${Id}`);
  } 


  DeleteSurgery(Id:number| undefined){ 
    return this.http.delete<Surgery>(`${this.endpoint}/Delete/Surgery/${Id}`);
  } 

  Update(Id:number| undefined, Info:Patient | undefined){
    return this.http.put<Patient>(`${this.endpoint}/Update/${Id}`,Info);
  }

  UpdateAllergy(Id:number| undefined, Info:Allergy | undefined){
    return this.http.put<Allergy>(`${this.endpoint}/Update/Allergy/${Id}`,Info);
  }

  UpdateCondition(Id:number| undefined, Info:Condition | undefined){
    return this.http.put<Condition>(`${this.endpoint}/Update/Condition/${Id}`,Info);
  }



  UpdateSurgery(Id:number| undefined, Info:Surgery | undefined){
    return this.http.put<Surgery>(`${this.endpoint}/Update/Surgery/${Id}`,Info);
  }

}
