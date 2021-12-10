import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { UserProfile } from '../Models/UserProfile';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user:UserProfile | null= {
    FirstName: "",
    LastName: "",
    DateOfBirth: "",
    PhoneNumber: "",
    Address: "",
    EmergencyName: "",
    EmergencyContactPhone: "",
    RoleId: 0,
    UserId: 0

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
    this.user = service.getProfile();
    this.employeeInfo = service.getEmplyoeeInfo();
  }

  ngOnInit(): void {
  }
}
