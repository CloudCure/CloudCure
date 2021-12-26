import { Assessment } from './../AngularModels/Assessment';
import { UserProfile } from './../AngularModels/UserProfile';
import { Component, OnInit, Input, Output } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Patient } from '../AngularModels/Patient';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {

  @Input() test: any

  viewConditions: boolean = false;
  viewAllergies: boolean = false;
  viewSurgeries: boolean = false;
  viewMedication: boolean = false;
  viewDiagnoses: boolean = false;

  patient: Patient = {} as Patient
  

  constructor(private patientApi: PatientService, private router: Router) {
    //1 will be changed later to a dynamic patient number
    this.patientApi.GetById(this.patientApi.currentPatientId).subscribe(response => {
      console.log("accessed patient")
      console.log(response)

      this.patient = response

    })
  }

  ngOnInit(): void {
  }

  // vitalsPage() {
  //   this.patientApi.currentPatientId = this.PatientId;
  //   this.router.navigateByUrl("/diagnosis-vitals");
  // }

  // assessmentsPage() {
  //   this.patientApi.currentPatientId = this.PatientId;
  //   this.router.navigateByUrl("/assessment");
  // }

  showConditions() {
    this.viewConditions = !this.viewConditions;
  }

  showAllergies() {
    this.viewAllergies = !this.viewAllergies;
  }

  showSurgeries() {
    this.viewSurgeries = !this.viewSurgeries;
  }

  showMedication() {
    this.viewMedication = !this.viewMedication;
  }

  showDiagnoses() {
    this.viewDiagnoses = !this.viewDiagnoses;
  }

  setDiagId(diagId: number) {
    this.patientApi.diagnosisId = diagId;
    this.router.navigateByUrl("/finalized-diagnosis-view");
  }
}
