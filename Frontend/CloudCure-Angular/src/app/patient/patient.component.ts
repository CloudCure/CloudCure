import { Component, OnInit } from '@angular/core';

import { Patient } from '../AngularModels/Patient';
import { User } from '@auth0/auth0-angular';
import { PatientService } from '../services/patient.service';
import { UserService } from '../services/user.service';

import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  //Creates a form group for the User model 
  registerGroup:FormGroup = new FormGroup({
    FirstName: new FormControl("", Validators.required),              //from UserProfile model
    LastName: new FormControl("", Validators.required),               //from UserProfile model
    DateOfBirth: new FormControl("", Validators.required),            //from UserProfile model
    PhoneNumber: new FormControl("", Validators.required),            //from UserProfile model
    Address: new FormControl("", Validators.required),                //from UserProfile model
    EmergencyName: new FormControl("", Validators.required),          //from UserProfile model
    EmergencyContactPhone: new FormControl("", Validators.required),  //from UserProfile model
    UserRole: new FormControl(3, Validators.required),                //from UserProfile model
    
  });
  get FirstName() {return this.registerGroup.get("FirstName");}
  get LastName() {return this.registerGroup.get("LastName");}
  get DateOfBirth() {return this.registerGroup.get("DateOfBirth");}
  get PhoneNumber() {return this.registerGroup.get("PhoneNumber");}
  get Address() {return this.registerGroup.get("Address");}
  get EmergencyName() {return this.registerGroup.get("EmergencyName");}
  get EmergencyContactPhone() {return this.registerGroup.get("EmergencyContactPhone");}

  date: Date = new Date;
  offset = this.date.getTimezoneOffset();
  today:string = "";

  constructor(private PatientApi: PatientService, private UserApi: UserService) { 
    
    this.date = new Date(this.date.getTime()-(this.offset*60*1000));
    this.today = this.date.toISOString().split('T')[0];
  }

  ngOnInit(): void {
  }


  RegisterPatient(registerGroup: FormGroup)
  {
    console.log("register complete")
    console.log(registerGroup);
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
        roleId: 3,
      }

        let PatientInfo: Patient = {
          userProfile: UserInfo,
        }
        console.log("Patient Info created");
        console.log(PatientInfo);

        this.PatientApi.Add(PatientInfo).subscribe(
          (response) => {
            console.log("Patient added");
            console.log(response);
          })

        }
        else
      {
        this.registerGroup.markAllAsTouched();
      }
    }
  }


