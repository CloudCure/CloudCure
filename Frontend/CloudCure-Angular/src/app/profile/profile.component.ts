import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Employee_Information } from '../Models/Employee_Information';
import { User_Profile } from '../Models/User_Profile';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userInfo:User_Profile | null = {
    first_Name: "",
    last_Name: "",
    employee_PhoneNumber: "",
    DateOfBirth: "",
    address: "",
    phone_Number: "",
    role_ID: -1,
    user_ID: -1
  };
  employeeInfo:Employee_Information | null = {
    education_Degree: "",
    room_Number: "",
    specialization: "",
    start_Date: "",
    user_ID: -1,
    work_Email: ""
  }

  constructor(public auth0:AuthService, service:ProfileService) {
    this.userInfo = service.getProfile();
    this.employeeInfo = service.getEmplyoeeInfo();
  }

  ngOnInit(): void {
  }
}
