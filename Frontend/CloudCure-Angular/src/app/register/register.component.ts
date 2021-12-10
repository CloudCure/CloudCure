import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserProfile } from '../Models/UserProfile';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Creates a form group for the User model 
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

  //when the submit button is clicked from the htlm of this component this function is called
  //will check if all verifications passed in the form group(so no feilds are null)
  //if verification passes it will create a new User object with the entered information
  RegisterUser(registerGroup: FormGroup)
  {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      //if (registerGroup.valid) {
        //let UserInfo:UserProfile ={
          
        //}
        //console.log(UserInfo);
      //}
      

  }

}
