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

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Patient";
  public currentPatientId: number | undefined = 0;
  public assigningDoctor: boolean = false;
  public patientCount: number = 0;
  public diagnosisId: number = 0;

  constructor(private http:HttpClient) {} 

  ////////////// Patient //////////////
  GetAll(){ 
    return this.http.get<Patient[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<Patient>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Patient | undefined){ 
    return this.http.post<Patient>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<Patient>(`${this.endpoint}/Delete/${Id}`);
  }  


  Update(Id:number| undefined, Info:Patient | undefined){
    return this.http.put<Patient>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
