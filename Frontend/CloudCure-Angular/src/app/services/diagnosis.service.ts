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
}
