import { Assessment } from './../AngularModels/Assessment';
import { UserProfile } from './../AngularModels/UserProfile';
import { Component, OnInit, Input } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {

  @Input() test: any

  patientExists: Boolean = true;
  //Patient Variables
  PatientId:          any;
  UserProfile:        any = {};
  PatientName:        string | undefined = 'Timmy';
  FirstName:          string = '';
  LastName:           string = '';
  PatientPhone:       any = '';
  PatientAddress:     any = '';
  DateOfBirth:        any = '';
  Conditions:         any = {};
  Allergies:          any = [];
  Surgeries:          any = [];
  CurrentMedications: any = [];
  VitalHistory:       any = [];
  Assessments:        any = [];

  viewConditions: boolean = false;
  viewAllergies: boolean = false;
  viewSurgeries: boolean =false;
  viewMedication: boolean = false;
  viewHistory: boolean = false;
  viewAssessment: boolean = false;

  constructor(private patientApi: PatientService, private router: Router) {
    //1 will be changed later to a dynamic patient number
    this.patientApi.GetById(this.patientApi.currentPatientId).subscribe(response => {
      console.log("accessed patient")
      console.log(response)
      this.patientExists = false;
      //Instantiating Patient Variables
      this.UserProfile =        response.userProfile
      this.FirstName =          this.UserProfile.firstName
      this.LastName =           this.UserProfile.lastName
      this.PatientName =        this.FirstName.concat(' ', this.LastName)
      this.PatientPhone =       this.UserProfile.phoneNumber
      this.PatientAddress =     this.UserProfile.address
      this.DateOfBirth =        this.UserProfile.dateOfBirth
      this.Conditions =         response.conditions
      this.Allergies =          response.allergies
      this.Surgeries =          response.surgeries
      this.CurrentMedications = response.currentMedications
      this.VitalHistory =       response.vitalHistory
      this.Assessments =        response.assessments

    })
   }

  ngOnInit(): void {
  }

  vitalsPage()
  {
    this.patientApi.currentPatientId = this.PatientId;
    this.router.navigateByUrl("/diagnosis-vitals");
  }

  assessmentsPage()
  {
    this.patientApi.currentPatientId = this.PatientId;
    this.router.navigateByUrl("/assessment");
  }

  showConditions()
  {
    this.viewConditions = !this.viewConditions;
  }

  showAllergies()
  {
    this.viewAllergies = !this.viewAllergies;
  }

  showSurgeries()
  {
    this.viewSurgeries = !this.viewSurgeries;
  }

  showMedication()
  {
    this.viewMedication = !this.viewMedication;
  }

  showHistory()
  {
    this. viewHistory = !this.viewHistory;
  }

  showAssessment()
  {
    this.viewAssessment = !this.viewAssessment;
  }

}
