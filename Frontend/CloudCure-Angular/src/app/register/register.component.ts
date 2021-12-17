import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { EmployeeService } from '../services/employee.service';
import { UserService } from '../services/user.service';
import { EmployeeInformation } from '../AngularModels/EmployeeInformation';
import { UserProfile } from '../AngularModels/UserProfile';



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
          firstName: registerGroup.get("FirstName")?.value,
          lastName: registerGroup.get("LastName")?.value,
          dateOfBirth: new Date(registerGroup.get("DateOfBirth")?.value).toISOString(),
          phoneNumber: registerGroup.get("PhoneNumber")?.value,
          address: registerGroup.get("Address")?.value,
          emergencyName: registerGroup.get("EmergencyName")?.value,
          emergencyContactPhone: registerGroup.get("EmergencyContactPhone")?.value,
          roleId: registerGroup.get("UserRole")?.value,
        }
        // this.userApi.Add(UserInfo).subscribe(
        //   (response) => {
            //console.log(response);
            //console.log(response.id);
            let EmployeeInfo: EmployeeInformation = {
              userProfile: UserInfo,
              workEmail: this.email,
              specialization: registerGroup.get("Specialization")?.value,
              startDate: new Date(registerGroup.get("StartDate")?.value).toISOString(),
              roomNumber: registerGroup.get("RoomNumber")?.value,
              educationDegree: registerGroup.get("EducationDegree")?.value
            }
            this.employeeApi.Add(EmployeeInfo).subscribe(
              (response) => {
                console.log(response);
              }
            )
        
      
      }
  }
}