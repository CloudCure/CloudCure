import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../AngularModels/UserProfile';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {

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

  constructor(private patientApi: PatientService) {
    //1 will be changed later to a dynamic patient number
    this.patientApi.GetById(1).subscribe(response => {
      console.log("accessed patient")
      console.log(response)
      this.patientExists = true;
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

}
