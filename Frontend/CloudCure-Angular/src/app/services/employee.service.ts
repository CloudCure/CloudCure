import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeInformation } from '../Models/EmployeeInformation';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(private http:HttpClient) { }

  ////////////// Employee //////////////
  verifyEmployee(p_email: string | undefined)
  {
    return this.http.get<EmployeeInformation>(`${this.endpoint}/EmployeeInformation/verify/${p_email}`)
  }

  getAllEmployees() 
  { 
    //this route will need to match route on API controller
    return this.http.get<EmployeeInformation[]>(`${this.endpoint}/EmployeeInformation/GetAll`);
  }

  getEmployeeById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<EmployeeInformation>(`${this.endpoint}/EmployeeInformation/Get`+Id);
  }

  addEmployee(Info:EmployeeInformation | undefined) : Observable<EmployeeInformation>
  { 
    //this route will need to match route on API controller
    return this.http.post<EmployeeInformation>(`${this.endpoint}/EmployeeInformation/Add`,Info);
  }  

  deleteEmployee(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<EmployeeInformation>(`${this.endpoint}/EmployeeInformation/Delete`+Id);
  } 


}
