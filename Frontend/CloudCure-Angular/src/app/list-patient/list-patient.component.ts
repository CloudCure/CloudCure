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
  constructor(private router: Router, private patientAPI:PatientService) {
    console.log(this.patient);
    
  }

  ngOnInit(): void {
  }

  allergy()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-allergy");
  }

  conditions()
  { 
    this.router.navigateByUrl("/diagnosis-condition");
  }

  diagnosis()
  { 
    this.router.navigateByUrl("/diagnosis");
  }

  medications()
  { 
    // this.router.navigateByUrl("/");
    console.log(this.patientAPI.currentPatientId);
  }

  surgeries()
  {
    this.router.navigateByUrl("/");
  }

  vitals()
  {
    this.router.navigateByUrl("/diagnosis-vitals");
  }
}
