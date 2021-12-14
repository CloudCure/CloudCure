import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeeInformation } from '../Models/EmployeeInformation';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(private http:HttpClient) { }

  ////////////// Employee //////////////
  GetAllEmployees() 
  { 
    //this route will need to match route on API controller
    return this.http.get<EmployeeInformation[]>(`${this.endpoint}/Covid/GetAll`);
  }

  GetEmployeeById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<EmployeeInformation>(`${this.endpoint}/Covid/Get`+Id);
  }

  AddEmployee(Info:EmployeeInformation | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<EmployeeInformation>(`${this.endpoint}/Covid/Add`,Info);
  }  

  DeleteEmployee(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<EmployeeInformation>(`${this.endpoint}/Covid/Delete`+Id);
  } 


}
