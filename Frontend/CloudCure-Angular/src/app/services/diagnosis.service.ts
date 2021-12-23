import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Diagnosis } from '../AngularModels/Diagnosis';

@Injectable({
  providedIn: 'root'
})
export class DiagnosisService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Diagnosis";
  constructor(public http: HttpClient) { }

  GetAll()
  {
    return this.http.get<Diagnosis[]>(`${this.endpoint}/Get/All`);
  }

  GetbyId(id:number | undefined)
  {
    return this.http.get<Diagnosis>(`${this.endpoint}/Get/${id}`);
  }

  Update(id:number | undefined, Info: Diagnosis | undefined)
  {
    return this.http.put<Diagnosis>(`${this.endpoint}/Update/${id}`, Info);
  }

  Delete(id:number | undefined)
  {
    return this.http.delete<Diagnosis>(`${this.endpoint}/Delete/${id}`);
  }

  GetByPatientIdWithNav(id:number | undefined)
  {
    return this.http.get<Diagnosis>(`${this.endpoint}/Get/GetPatientId/${id}`);
  }

  GetAllDiagnosisByPatientIdWithNav(id:number | undefined)
  {
    return this.http.get<Diagnosis[]>(`${this.endpoint}/Get/GetAllPatient/${id}`);
  }

  Add(Info: Diagnosis | undefined)
  {
    return this. http.post<Diagnosis>(`${this.endpoint}/Add`, Info);
  }

}

