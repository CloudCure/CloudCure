import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User_Profile } from '../Models/User_Profile';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user:User_Profile | null= {
    employee_FirstName: "",
    employee_LastName: "",
    employee_PhoneNumber: "",
    employee_Specialization: "",
    emergency_Contact: "",
    user_Role: "",
    work_Email: "",
    alternate_Email: ""
  };

  constructor(public auth0:AuthService, service:ProfileService) {
    this.user = service.getProfile();
  }

  ngOnInit(): void {
  }
}
