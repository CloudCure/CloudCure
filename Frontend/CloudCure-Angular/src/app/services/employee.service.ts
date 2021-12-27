import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeeInformation } from '../AngularModels/EmployeeInformation';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/EmployeeInformation";
  public currentEmployee: EmployeeInformation | undefined;
  constructor(private http:HttpClient) { }

  ////////////// Employee //////////////
  verifyEmployee(p_email: string | undefined){
    return this.http.get<EmployeeInformation>(`${this.endpoint}/Verify/${p_email}`)
  }

  GetAll(){
    return this.http.get<EmployeeInformation[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){
    return this.http.get<EmployeeInformation>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:EmployeeInformation | undefined){
    return this.http.post<EmployeeInformation>(`${this.endpoint}/Add`,Info);
  }  

  Delete(Id:number | undefined){
    return this.http.delete<EmployeeInformation>(`${this.endpoint}/Delete/${Id}`);
  } 

  Update(Info:EmployeeInformation | undefined, Id:Number | undefined){
    return this.http.put<EmployeeInformation>(`${this.endpoint}/Update/${Id}`,Info);
  }


}
