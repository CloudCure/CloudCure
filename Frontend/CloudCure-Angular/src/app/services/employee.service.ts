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
    return this.http.get<EmployeeInformation[]>(`${this.endpoint}/Employee/GetAll`);
  }

  GetEmployeeById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<EmployeeInformation>(`${this.endpoint}/Employee/Get/${Id}`);
  }

  AddEmployee(Info:EmployeeInformation | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<EmployeeInformation>(`${this.endpoint}/Employee/Add`,Info);
  }  

  DeleteEmployee(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<EmployeeInformation>(`${this.endpoint}/Employee/Delete/${Id}`);
  } 


}
