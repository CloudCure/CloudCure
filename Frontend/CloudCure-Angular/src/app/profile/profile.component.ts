import { EmployeeInformation } from './../AngularModels/EmployeeInformation';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { UserProfile } from '../AngularModels/UserProfile';
import { EmployeeService } from '../services/employee.service';

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
    id: 0

  };
  employee:EmployeeInformation={
  WorkEmail: "string",
  Specialization: "string",
  StartDate: "string",
  RoomNumber: "string",
  EducationDegree: "string",
  user: undefined,
  UserProfile: undefined
  }

  email:string | undefined = '';
  constructor(private employeeApi: EmployeeService, private userApi: UserService, private auth0: AuthService)
  {
    this.auth0.user$.subscribe(
      (user) => {
        this.email = user?.email;

        this.employeeApi.verifyEmployee(this.email).subscribe(
          (response) => {
            console.log(response);
            this.employee=response


            console.log(response);

            this.employeeApi.GetById(29).subscribe(
              (response2) => {
                console.log(response2);
              }
            )
          }
        )

      }
    )
  }


  ngOnInit(): void {
  }


  // changes tabs in main card
  id:any= "dashboard";
  tabChange(ids:any){
    this.id = ids;
  }
}
