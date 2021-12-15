import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Roles } from '../AngularModels/Roles';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private endpoint: string = "https://cloudcure-api.azurewebsites.net";
  constructor(private http:HttpClient) { }

  ////////////// Roles //////////////
  GetAllRoles() 
  { 
    //this route will need to match route on API controller
    return this.http.get<Roles[]>(`${this.endpoint}/Roles/GetAll`);
  }

  GetRoleById(Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<Roles>(`${this.endpoint}/Roles/Get/${Id}`);
  }

  AddRole(Info:Roles | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.post<Roles>(`${this.endpoint}/Roles/Add`,Info);
  }  

  EditRole(Info:Roles | undefined, Id:Number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.put<Roles>(`${this.endpoint}/Roles/edit/${Id}`,Info);
  } 

  DeleteRole(Id:number | undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.delete<Roles>(`${this.endpoint}/Roles/Delete/${Id}`);
  } 

}
