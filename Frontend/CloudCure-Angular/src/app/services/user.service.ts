import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../Models/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(public http:HttpClient) { }

  ////////////// User //////////////
  GetAllUsers() 
  { 
    //this route will need to match route on API controller
    return this.http.get<UserProfile[]>(`${this.endpoint}/User/GetAll`);
  }

  GetUserById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<UserProfile>(`${this.endpoint}/User/Get`+Id);
  }

  AddUser(Info:UserProfile | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<UserProfile>(`${this.endpoint}/User/Add`,Info);
  }  

  DeleteUser(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<UserProfile>(`${this.endpoint}/User/Delete`+Id);
  } 

}
