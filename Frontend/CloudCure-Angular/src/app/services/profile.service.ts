import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee_Information } from '../Models/Employee_Information';
import { User_Profile } from '../Models/User_Profile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(http: HttpClient) { }

  getProfile() : User_Profile | null {
    return null;
  }
  getEmplyoeeInfo() : Employee_Information | null {
    return null;
  }
}