import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { EmployeeInformation } from '../Models/EmployeeInformation';
import { UserProfile } from '../Models/UserProfile';
import { EmployeeService } from '../services/employee.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Creates a form group for the User model 
  registerGroup:FormGroup = new FormGroup({
      WorkEmail: new FormControl(""),//from EmployeeInformation model
      FirstName: new FormControl("", Validators.required),//from UserProfile model
      LastName: new FormControl("", Validators.required),//from UserProfile model
      DateOfBirth: new FormControl("", Validators.required),//from UserProfile model
      PhoneNumber: new FormControl("", Validators.required),//from UserProfile model
      Address: new FormControl("", Validators.required),//from UserProfile model
      EmergencyName: new FormControl("", Validators.required),//from UserProfile model
      EmergencyContactPhone: new FormControl("", Validators.required),//from UserProfile model
      Specialization: new FormControl("", Validators.required),//from EmployeeInformation model
      StartDate: new FormControl("", Validators.required),//from EmployeeInformation model
      EducationDegree: new FormControl("", Validators.required),//from EmployeeInformation model
      RoomNumber: new FormControl("", Validators.required),//from EmployeeInformation model
      UserRole: new FormControl("", Validators.required),// RoleId from UserProfile model
      
  });
  email:string | undefined = '';
  constructor(private employeeApi: EmployeeService, private userApi: UserService, private auth0: AuthService) 
  { 
    this.auth0.user$.subscribe(
      (user) => {
        this.email = user?.email;
      }
    )
  }

  ngOnInit(): void {
  }

  //when the submit button is clicked from the htlm of this component this function is called
  //will check if all verifications passed in the form group(so no feilds are null)
  //if verification passes it will create a new User object with the entered information
  RegisterUser(registerGroup: FormGroup)
  {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      if (registerGroup.valid) {
        let UserInfo: UserProfile = {
          FirstName: registerGroup.get("FirstName")?.value,
          LastName: registerGroup.get("LastName")?.value,
          DateOfBirth: new Date(registerGroup.get("DateOfBirth")?.value).toISOString(),
          PhoneNumber: registerGroup.get("PhoneNumber")?.value,
          Address: registerGroup.get("Address")?.value,
          EmergencyName: registerGroup.get("EmergencyName")?.value,
          EmergencyContactPhone: registerGroup.get("EmergencyContactPhone")?.value,
          RoleId: registerGroup.get("UserRole")?.value,
        }
        this.userApi.AddUser(UserInfo).subscribe(
          (response) => {
            console.log(response);
            console.log(response.id);
            let EmployeeInfo: EmployeeInformation = {
              UserProfileId: response.id,
              WorkEmail: this.email,
              Specialization: registerGroup.get("Specialization")?.value,
              StartDate: new Date(registerGroup.get("StartDate")?.value).toISOString(),
              RoomNumber: registerGroup.get("RoomNumber")?.value,
              EducationDegree: registerGroup.get("EducationDegree")?.value
            }
            this.employeeApi.addEmployee(EmployeeInfo).subscribe(
              (response) => {
                console.log(response);
              }
            )
          }
        )
      }
  }
}
