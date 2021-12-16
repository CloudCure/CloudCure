import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Patient } from '../AngularModels/Patient';
import { UserProfile } from '../AngularModels/UserProfile';
import { PatientService } from '../services/patient.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  @Input('patient') patient: Patient;

  @Output('patient') patientChange = new EventEmitter<Patient>();

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

  constructor(private PatientApi: PatientService, private UserApi: UserService) { 
    this.patient = {
      UserProfile: {
        FirstName: "",
        LastName: "",
        DateOfBirth: new Date(),
        PhoneNumber: "",
        Address: "",
        EmergencyName: "",
        EmergencyContactPhone: "",
        RoleId: 3,
    }}
  }

  ngOnInit(): void {
  }

  
}


