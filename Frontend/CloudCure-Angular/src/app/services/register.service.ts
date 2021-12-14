import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  //endpoint will need to change to match correct endpoint
  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(private http:HttpClient) 
  { 

  }

  ////////////// User //////////////
  //takes the email fron auth0
  RegisterUser(p_email:string|undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<any>(`${this.endpoint}/user/Register`,p_email);
  }

  ////////////// Employee //////////////
  //takes the id of the created user then adds the additonal info to make an employee
  RegisterEmplyee(Id:Number|undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<any>(`${this.endpoint}/EmployeeInformation/Register`,Id);
  }


}
