import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserProfile } from '../AngularModels/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/api/UserProfile";
  constructor(private http:HttpClient) { }

  ////////////// UserProfile //////////////
  GetAll(){
    return this.http.get<UserProfile[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){
    return this.http.get<UserProfile>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:UserProfile | undefined){
    return this.http.post<UserProfile>(`${this.endpoint}/Add`,Info);
  }  

  Update(Info:UserProfile | undefined, Id:Number | undefined){
    return this.http.put<UserProfile>(`${this.endpoint}/Update/${Id}`,Info);
  } 

  Delete(Id:number | undefined){
    return this.http.delete<UserProfile>(`${this.endpoint}/Delete/${Id}`);
  } 
}