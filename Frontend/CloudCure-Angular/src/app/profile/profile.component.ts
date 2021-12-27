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

  employee: EmployeeInformation = {} as EmployeeInformation

  email: string | undefined = '';
  role: any
  constructor(private employeeApi: EmployeeService, private userApi: UserService, private auth0: AuthService) {
    this.auth0.user$.subscribe(
      (user) => {
        this.email = user?.email;

        this.employeeApi.verifyEmployee(this.email).subscribe(
          (response) => {
            console.log(response);
            this.employee = response
            this.role = this.employee.userProfile.role?.roleName
            console.log(response);
          }
        )
      }
    )
  }

  ngOnInit(): void {
  }

  // changes tabs in main card
  id: any = "dashboard";
  tabChange(ids: any) {
    this.id = ids;
  }
}
