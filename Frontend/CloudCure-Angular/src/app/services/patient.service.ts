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

  GetAllMedications(){ 
    return this.http.get<Medication[]>(`${this.endpoint}/Get/All/Medications`);
  }

  GetAllSurgeries(){ 
    return this.http.get<Surgery[]>(`${this.endpoint}/Get/All/Surgeries`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Patient>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Patient | undefined){ 
    return this.http.post<Patient>(`${this.endpoint}/Add`,Info);
  }  

  AddAllgergy(Info:Allgergy | undefined){ 
    return this.http.post<Allgergy>(`${this.endpoint}/Add/Allgergy`,Info);
  }  

  AddCondition(Info:Condition | undefined){ 
    return this.http.post<Condition>(`${this.endpoint}/Add/Condition`,Info);
  }  

  AddMedication(Info:Medication | undefined){ 
    return this.http.post<Medication>(`${this.endpoint}/Add/Medication`,Info);
  }  

  AddSurgery(Info:Surgery | undefined){ 
    return this.http.post<Surgery>(`${this.endpoint}/Add/Surgery`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<Patient>(`${this.endpoint}/Delete/${Id}`);
  }  

  DeleteAllgergy(Id:number| undefined){ 
    return this.http.delete<Allgergy>(`${this.endpoint}/Delete/Allgergy/${Id}`);
  } 

  DeleteCondition(Id:number| undefined){ 
    return this.http.delete<Condition>(`${this.endpoint}/Delete/Condition/${Id}`);
  } 

  DeleteMedication(Id:number| undefined){ 
    return this.http.delete<Medication>(`${this.endpoint}/Delete/${Id}`);
  } 

  DeleteSurgery(Id:number| undefined){ 
    return this.http.delete<Surgery>(`${this.endpoint}/Delete/Surgery/${Id}`);
  } 

  Update(Id:number| undefined, Info:Patient | undefined){
    return this.http.put<Patient>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
