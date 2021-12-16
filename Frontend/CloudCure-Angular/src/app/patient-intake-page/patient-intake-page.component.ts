import { Component, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { UserProfile } from '../AngularModels/UserProfile';
import { PatientService } from '../services/patient.service';
import { UserService } from '../services/user.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-patient-intake-page',
  templateUrl: './patient-intake-page.component.html',
  styleUrls: ['./patient-intake-page.component.css']
})
export class PatientIntakePageComponent implements OnInit {

  basicpatient: Patient;
  constructor(private PatientApi: PatientService) {
    this.basicpatient = {
      UserProfile: {
        FirstName: "",
        LastName: "",
        DateOfBirth: new Date(),
        PhoneNumber: "",
        Address: "",
        EmergencyName: "",
        EmergencyContactPhone: "",
        RoleId: 3,
      },
      Conditions: [],
      Allergies: [],
      Surgeries: [],
      CurrentMedications: [],
      VitalHistory: [],
      Assessments: [],
    }
  }

  ngOnInit(): void {
  }

  RegisterPatient(){
    if(this.basicpatient.PatientId == null || this.basicpatient.PatientId == undefined){
    this.PatientApi.Add(this.basicpatient).subscribe(
      (response) => {
        console.log(response);
    })}
    else{
    this.PatientApi.Update(this.basicpatient.PatientId, this.basicpatient).subscribe(
      (response) => {
        console.log(response);
    })}
    
  }

}
