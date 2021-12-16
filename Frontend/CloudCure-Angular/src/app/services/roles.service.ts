import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Roles } from '../AngularModels/Roles';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net/Roles";
  constructor(private http:HttpClient) { }

  ////////////// Roles //////////////
  GetAll(){
    return this.http.get<Roles[]>(`${this.endpoint}/Get/All`);
  }

  GetById(Id:Number | undefined){
    return this.http.get<Roles>(`${this.endpoint}/Get/${Id}`);
  }

  Add(Info:Roles | undefined){
    return this.http.post<Roles>(`${this.endpoint}/Add`,Info);
  }  

  Update(Info:Roles | undefined, Id:Number | undefined){
    return this.http.put<Roles>(`${this.endpoint}/Update/${Id}`,Info);
  } 

  Delete(Id:number | undefined){
    return this.http.delete<Roles>(`${this.endpoint}/Delete/${Id}`);
  } 

}
