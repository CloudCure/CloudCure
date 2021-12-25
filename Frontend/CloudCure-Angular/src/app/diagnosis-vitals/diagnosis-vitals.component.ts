import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VirtualAction } from 'rxjs';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';
import { Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { AssessmentService } from '../services/assessement.service';

@Component({
  selector: 'diagnosis-vitals',
  templateUrl: './diagnosis-vitals.component.html',
  styleUrls: ['./diagnosis-vitals.component.css']
})
export class DiagnosisVitalsComponent implements OnInit {

  // makes the form group for our vitals
  vitalsGroup: FormGroup = new FormGroup({
    Systolic: new FormControl("", Validators.required),
    Diastolic: new FormControl("", Validators.required),
    OxygenSat: new FormControl("", Validators.required),
    HeartRate: new FormControl("", Validators.required),
    Temperature: new FormControl("", Validators.required),
    RespiratoryRate: new FormControl("", Validators.required),
    Height: new FormControl("", Validators.required),
    Weight: new FormControl("", Validators.required),
  });


  patient: Patient = {} as Patient;
  newVitals: Vitals = {} as Vitals;
  diagnosisId: any;

  constructor(private VitalsAPI: VitalsService, private PatientAPI: PatientService, private route: ActivatedRoute, private router: Router) {
    this.PatientAPI.GetById(this.PatientAPI.currentPatientId).subscribe(result => {
      this.patient = result
      this.diagnosisId = this.patient.diagnoses![this.patient.diagnoses!.length - 1].id

      console.log(this.diagnosisId)
    })
  }

  ngOnInit(): void {
    this.VitalsAPI.submitButton;
  }

  PatientProfile() {
    this.RegisterVitals(this.vitalsGroup)
    this.router.navigateByUrl("home");
  }

  Assessments() {
    this.RegisterVitals(this.vitalsGroup)
    this.router.navigateByUrl("/assessment");
  }

  // function that runs on form submission
  RegisterVitals(vitalsGroup: FormGroup) {
    // logs the form
    console.log("register complete")
    console.log(vitalsGroup)

    // checks to see if form is valid
    if (vitalsGroup.valid) {
      this.newVitals.diagnosisId = this.diagnosisId
      this.newVitals.systolic = vitalsGroup.get("Systolic")?.value,
      this.newVitals.diastolic = vitalsGroup.get("Diastolic")?.value,
      this.newVitals.oxygenSat = vitalsGroup.get("OxygenSat")?.value,
      this.newVitals.heartRate = vitalsGroup.get("HeartRate")?.value,
      this.newVitals.temperature = vitalsGroup.get("Temperature")?.value,
      this.newVitals.respiratoryRate = vitalsGroup.get("RespiratoryRate")?.value,
      this.newVitals.height = vitalsGroup.get("Height")?.value,
      this.newVitals.weight = vitalsGroup.get("Weight")?.value
      
      this.VitalsAPI.Add(this.newVitals).subscribe(result => {
        this.newVitals = result;
      })
    }
  }
}
