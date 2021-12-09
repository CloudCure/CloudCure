import { Component, OnInit } from '@angular/core';
// import { AuthService } from '@auth0/auth0-angular';
import { User_Profile } from '../Models/User_Profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user:User_Profile = {
    employee_FirstName: "",
    employee_LastName: "",
    employee_PhoneNumber: "",
    employee_Specialization: "",
    emergency_Contact: "",
    user_Role: "",
    work_Email: "",
    alternate_Email: ""
  };

  // public auth0:AuthService
  constructor() { //need to include whatever service we will have to connect to the backend in the parameters
    //In here we will call the service to get all the info from the backend
  }

  ngOnInit(): void {
  }
}
