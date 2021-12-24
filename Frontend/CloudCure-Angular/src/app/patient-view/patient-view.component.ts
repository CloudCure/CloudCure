import { Assessment } from './../AngularModels/Assessment';
import { UserProfile } from './../AngularModels/UserProfile';
import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {

  @Input() test: any

  //Patient Variables
  PatientId: any;
  UserProfile: any = {};
  PatientName: string | undefined = 'Timmy';
  FirstName: string = '';
  LastName: string = '';
  PatientPhone: any = '';
  PatientAddress: any = '';
  DateOfBirth: any = '';
  Conditions: any = {};
  Allergies: any = [];
  Surgeries: any = [];
  CurrentMedications: any = [];
  Diagnoses: any = []

  viewConditions: boolean = false;
  viewAllergies: boolean = false;
  viewSurgeries: boolean = false;
  viewMedication: boolean = false;
  viewDiagnoses: boolean = false;

  constructor(private patientApi: PatientService, private router: Router) {
    //1 will be changed later to a dynamic patient number
    this.PatientId = patientApi.currentPatientId;
    this.patientApi.GetById(this.patientApi.currentPatientId).subscribe(response => {
      console.log("accessed patient")
      console.log(response)
      //Instantiating Patient Variables
      this.UserProfile = response.userProfile
      this.FirstName = this.UserProfile.firstName
      this.LastName = this.UserProfile.lastName
      this.PatientName = this.FirstName.concat(' ', this.LastName)
      this.PatientPhone = this.UserProfile.phoneNumber
      this.PatientAddress = this.UserProfile.address
      this.DateOfBirth = this.UserProfile.dateOfBirth
      this.Conditions = response.conditions
      this.Allergies = response.allergies
      this.Surgeries = response.surgeries
      this.CurrentMedications = response.currentMedications
      this.Diagnoses = response.diagnoses

    })
  }

  ngOnInit(): void {
  }

  vitalsPage() {
    this.patientApi.currentPatientId = this.PatientId;
    this.router.navigateByUrl("/diagnosis-vitals");
  }

  assessmentsPage() {
    this.patientApi.currentPatientId = this.PatientId;
    this.router.navigateByUrl("/assessment");
  }

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


}
