import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeeInformation } from '../Models/EmployeeInformation';
import { UserProfile } from '../Models/UserProfile';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(http: HttpClient) { }

  getProfile() : UserProfile | null {
    return null;
  }
  getEmployeeInfo() : EmployeeInformation | null {
    return null;
  }
}