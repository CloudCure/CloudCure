import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//import { Console } from 'console';
import { Assessment } from '../AngularModels/Assessment';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { DiagnosisService } from '../services/diagnosis.service';

@Component({
  selector: 'app-finalized-diagnosis-view',
  templateUrl: './finalized-diagnosis-view.component.html',
  styleUrls: ['./finalized-diagnosis-view.component.css']
})
export class FinalizedDiagnosisViewComponent implements OnInit {

  Id : Number | undefined;
  EncounterDate : Date | undefined;
  Patient : Patient | undefined;
  Vitals : Vitals | undefined;
  Assessment : Assessment | undefined;
  DoctorDiagnosis : String | undefined;
  RecommendedTreatment : String | undefined;
  IsFinalized : Boolean | undefined;
  

  constructor(private DiagnosisApi : DiagnosisService, private router : Router) {
    this.DiagnosisApi.GetByPatientIdWithNav(1).subscribe((response) => {
      console.log(response);
      this.Id = response.id;
      this.EncounterDate = response.EncounterDate;
      this.Patient = response.Patient;
      this.Vitals = response.vitals;
      this.Assessment = response.Assessment;
      this.DoctorDiagnosis = response.DoctorDiagnosis;
      this.RecommendedTreatment = response.RecommendedTreatment;
      this.IsFinalized = response.IsFinalized;
    }) 
   }

  ngOnInit(): void {
  }

}
