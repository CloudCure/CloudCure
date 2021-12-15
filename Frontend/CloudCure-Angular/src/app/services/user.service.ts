import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
<<<<<<< HEAD
import { Observable } from 'rxjs';
import { UserProfile } from '../Models/UserProfile';
=======
import { UserProfile } from '../AngularModels/UserProfile';
>>>>>>> main

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/User";
  constructor(public http:HttpClient) { }

  ////////////// User //////////////
  GetAll(){
    return this.http.get<UserProfile[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){
    return this.http.get<UserProfile>(`${this.endpoint}/Get/${Id}`);
  }

<<<<<<< HEAD
  AddUser(Info:UserProfile | undefined) : Observable<UserProfile>
  { 
    //this route will need to match route on API controller
    return this.http.post<UserProfile>(`${this.endpoint}/User/Add`,Info);
=======
  Add(Info:UserProfile | undefined){
    return this.http.post<UserProfile>(`${this.endpoint}/Add`,Info);
>>>>>>> main
  }  

  Delete(Id:number | undefined){
    return this.http.delete<UserProfile>(`${this.endpoint}/Delete/${Id}`);
  } 

  Update(Id:number | undefined, Info:UserProfile | undefined){
    return this.http.put<UserProfile>(`${this.endpoint}/Update/${Id}`,Info);
  }

}
