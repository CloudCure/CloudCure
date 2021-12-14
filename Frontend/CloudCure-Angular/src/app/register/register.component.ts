import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeInformation } from '../Models/EmployeeInformation';
import { UserProfile } from '../Models/UserProfile';


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

  constructor() { }

  ngOnInit(): void {
  }

  //when the submit button is clicked from the htlm of this component this function is called
  //will check if all verifications passed in the form group(so no feilds are null)
  //if verification passes it will create a new User object with the entered information
  RegisterUser(registerGroup: FormGroup)
  {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      if (registerGroup.valid) {
        let UserInfo:UserProfile ={
          FirstName : registerGroup.get("FirstName")?.value,
          LastName : registerGroup.get("LastName")?.value,
          DateOfBirth: registerGroup.get("DateOfBirth")?.value,
          PhoneNumber : registerGroup.get("PhoneNumber")?.value,
          Address : registerGroup.get("Address")?.value,
          EmergencyName : registerGroup.get("EmergencyName")?.value,
          EmergencyContactPhone: registerGroup.get("EmergencyContactPhone")?.value,
          RoleId : registerGroup.get("UserRole")?.value,
        }
        let EmployeeInfo: EmployeeInformation
        //do add user with info from UserInfo here
        if(true/*if 200 code is receved from user add do this*/)
        {
          EmployeeInfo ={
            //user_ID willbe the same value as the id from the created user that was added above
            WorkEmail: registerGroup.get("WorkEmail")?.value,
            Specialization: registerGroup.get("Specialization")?.value,
            StartDate: registerGroup.get("StartDate")?.value,
            RoomNumber: registerGroup.get("RoomNumber")?.value,
            EducationDegree: registerGroup.get("EducationDegree")?.value,
          }
        }
        console.log(UserInfo);
        console.log(EmployeeInfo);
      }
      

  }

}
