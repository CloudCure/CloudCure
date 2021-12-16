import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
<<<<<<< HEAD
import { Observable } from 'rxjs';
import { EmployeeInformation } from '../Models/EmployeeInformation';
=======
import { EmployeeInformation } from '../AngularModels/EmployeeInformation';
>>>>>>> main

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/EmployeeInformation";
  constructor(private http:HttpClient) { }

  ////////////// Employee //////////////
<<<<<<< HEAD
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
=======
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
>>>>>>> main
  } 

  Update(Info:EmployeeInformation | undefined, Id:Number | undefined){
    return this.http.put<EmployeeInformation>(`${this.endpoint}/Update/${Id}`,Info);
  }


}
