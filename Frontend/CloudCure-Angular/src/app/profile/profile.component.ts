import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { EmployeeInformation } from '../Models/EmployeeInformation';
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
  employeeInfo:EmployeeInformation | null = {
    EducationDegree: "",
    RoomNumber: "",
    Specialization: "",
    StartDate: "",
    UserId: 0,
    WorkEmail: ""
  }

  constructor(public auth0:AuthService, service:ProfileService) {
    this.user = service.getProfile();
    this.employeeInfo = service.getEmployeeInfo();
  }

  ngOnInit(): void {
  }
}
