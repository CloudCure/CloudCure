import { Component, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';
import { UserService } from '../services/user.service';
import { User } from '@auth0/auth0-angular';
import { PatientService } from '../services/patient.service';
import { Allergy } from '../AngularModels/Allergy';
import { Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { Assessment } from '../AngularModels/Assessment';
import { Vitals } from '../AngularModels/Vitals';
import { DiagnosisService } from '../services/diagnosis.service';

@Component({
  selector: 'app-list-patient',
  templateUrl: './list-patient.component.html',
  styleUrls: ['./list-patient.component.css']
})
export class ListPatientComponent implements OnInit, OnDestroy {

  @Input()
  patient: Patient = {} as Patient;

  @Input()
  role: number = 0;

  pairedDoctor:string = '';
  newDiagnosis : Diagnosis = {} as Diagnosis

  constructor(private router: Router, private patientAPI:PatientService, private diagnosisAPI: DiagnosisService) {
  }
  ngOnDestroy(): void {
    this.patientAPI.patientCount = 0;
  }

  ngOnInit(): void {
    if (this.patientAPI.patientCount > 0) {
      this.pairedDoctor = "test"
    }
    this.patientAPI.patientCount--;

    console.log(this.patient)

  }

  createDiagnosis()
  {
    this.newDiagnosis.assessment = undefined
    this.newDiagnosis.vitals = undefined
    this.newDiagnosis.patientId = this.patient.id
    this.newDiagnosis.doctorDiagnosis = undefined
    this.newDiagnosis.recommendedTreatment = undefined
    this.newDiagnosis.isFinalized = false
    console.log(this.newDiagnosis)
    this.diagnosisAPI.Add(this.newDiagnosis).subscribe(result => {
      this.newDiagnosis = result
      this.router.navigateByUrl("");
    })
  }

  addProfile()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis");
  }

  viewVitals()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/diagnosis-vitals");
  }

  viewAssessments()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/assessment");
  }

  viewProfile()
  {
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/patient-view");
  }

  assignDoctor()
  {
    this.patientAPI.assigningDoctor = true;
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl('/search');
  }

  finalize()
  {
    //not sure what we do when we finalize?
    this.patientAPI.currentPatientId = this.patient.id;
    this.router.navigateByUrl("/view-diagnosis");
  }
}
