import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User_Profile } from '../Models/User_Profile';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerGroup:FormGroup = new FormGroup({
      work_Email: new FormControl(""),
      FirstName: new FormControl("", Validators.required),
      LastName: new FormControl("", Validators.required),
      PhoneNumber: new FormControl("", Validators.required),
      Specialization: new FormControl("", Validators.required),
      alternate_Email: new FormControl("", Validators.required),
      emergency_Contact: new FormControl("", Validators.required),
      user_Role: new FormControl("", Validators.required),
      
  });

  constructor() { }

  ngOnInit(): void {
  }

  RegisterUser(registerGroup: FormGroup)
  {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      if (registerGroup.valid) {
        let UserInfo:User_Profile ={
          work_Email : registerGroup.get("work_email")?.value,
          employee_FirstName : registerGroup.get("FirstName")?.value,
          employee_LastName : registerGroup.get("LastName")?.value,
          employee_PhoneNumber: registerGroup.get("PhoneNumber")?.value,
          employee_Specialization : registerGroup.get("Specialization")?.value,
          alternate_Email : registerGroup.get("alternate_Email")?.value,
          emergency_Contact : registerGroup.get("emergency_Contact")?.value,
          user_Role : registerGroup.get("user_Role")?.value,
        }
        console.log(UserInfo);
      }
      

  }

}
