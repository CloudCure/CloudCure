import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {
  //endpoint will need to change to match correct endpoint
  private endpoint: string = "";
  constructor(private http:HttpClient) 
  {

  }
  ////////////// User //////////////
  loginUser(p_email:string|undefined) 
  { 
    //this route will need to match route on API controller
    return this.http.get<any>(`${this.endpoint}/user/login/${p_email}`);
  }
}
