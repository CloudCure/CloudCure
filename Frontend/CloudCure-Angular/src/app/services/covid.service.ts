import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CovidVerify } from '../AngularModels/CovidVerify';
import { Patient } from '../AngularModels/Patient';
import { PatientService } from './patient.service';

@Injectable({
  providedIn: 'root'
})
export class CovidService {

  patient: Patient = {} as Patient

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Covid";
  constructor(private http:HttpClient, private PatientApi: PatientService) {
    this.PatientApi.GetById(this.PatientApi.currentPatientId).subscribe(result => {
      this.patient = result
    })
  } 

  ////////////// Covid //////////////
  GetAll(){ 
    return this.http.get<CovidVerify[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){ 
    return this.http.get<CovidVerify>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:CovidVerify | undefined){ 
    return this.http.post<CovidVerify>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number| undefined){ 
    return this.http.delete<CovidVerify>(`${this.endpoint}/Delete/${Id}`);
  }  

  Update(Id:number| undefined, Info:CovidVerify | undefined){
    return this.http.put<CovidVerify>(`${this.endpoint}/Update/${Id}`,Info);
  }
}
