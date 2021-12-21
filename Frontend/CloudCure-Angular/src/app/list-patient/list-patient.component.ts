import { Component, Input, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';
import { UserService } from '../services/user.service';
import { User } from '@auth0/auth0-angular';
import { PatientService } from '../services/patient.service';
import { Allergy } from '../AngularModels/Allergy';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-patient',
  templateUrl: './list-patient.component.html',
  styleUrls: ['./list-patient.component.css']
})
export class ListPatientComponent implements OnInit {

  @Input()
  patient: Patient = {} as Patient;

  @Input()
  role: number = 0;

  constructor(private router: Router, private patientAPI:PatientService) {
    console.log(this.patient);
    
  }

  ngOnInit(): void {
  }

  allergies()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-allergy");
  }

  viewAllergies()
  {

  }

  conditions()
  { 
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-condition");
  }

  viewConditions()
  {

  }

  assessments()
  { 
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/assessment");
  }

  viewAssessments()
  {

  }

  medications()
  { 
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-medication");
  }

  viewMedications()
  {

  }

  surgeries()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-surgeries");
  }

  viewSurgeries()
  {

  }

  vitals()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-vitals");
  }

  viewVitals()
  {

  }

  finalize()
  {
    //not sure what we do when we finalize?
    this.router.navigateByUrl("/view-diagnosis");
  }
}
