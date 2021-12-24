import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VirtualAction } from 'rxjs';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';
import { Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';

@Component({
  selector: 'diagnosis-vitals',
  templateUrl: './diagnosis-vitals.component.html',
  styleUrls: ['./diagnosis-vitals.component.css']
})
export class DiagnosisVitalsComponent implements OnInit, OnDestroy {

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

  OurBoolean: boolean = true;

  constructor(private VitalsAPI: VitalsService, private PatientAPI: PatientService, private route: ActivatedRoute, private router: Router) { }

  patientId: number | undefined = this.PatientAPI.currentPatientId
  patient: Patient = {} as Patient;
  newVitals: Vitals = {} as Vitals;
  diagnosis: Diagnosis = {} as Diagnosis;

  ngOnDestroy(): void {
    this.VitalsAPI.submitButton = false;
  }

  ngOnInit(): void {
    this.VitalsAPI.submitButton;
    this.OurBoolean = this.VitalsAPI.submitButton
    // this way has worked in the past
    // depends on how we wish to implement Patient ID in the routing
    // this.patientId = Number(this.route.snapshot.paramMap.get("id"))

    this.PatientAPI.GetById(this.patientId).subscribe(result => {
      result = this.patient;
    })
  }

  submit() {
    this.OurBoolean = false;
    this.router.navigateByUrl("/profile");
  }

  submitOne() {
    this.OurBoolean = false;
    this.router.navigateByUrl("/patient");
  }



  PatientProfile() {
    this.router.navigateByUrl("patient-view");
  }

  Assessments() {
    this.router.navigateByUrl("/assessment");
  }

  // function that runs on form submission
  RegisterVitals(vitalsGroup: FormGroup) {
    // logs the form
    console.log("register complete")
    console.log(vitalsGroup)
    this.OurBoolean = false;

    // checks to see if form is valid
    if (vitalsGroup.valid) {
      this.newVitals.systolic = vitalsGroup.get("Systolic")?.value,
      this.newVitals.diastolic = vitalsGroup.get("Diastolic")?.value,
      this.newVitals.oxygenSat = vitalsGroup.get("OxygenSat")?.value,
      this.newVitals.heartRate = vitalsGroup.get("HeartRate")?.value,
      this.newVitals.temperature = vitalsGroup.get("Temperature")?.value,
      this.newVitals.respiratoryRate = vitalsGroup.get("RespiratoryRate")?.value,
      this.newVitals.height = vitalsGroup.get("Height")?.value,
      this.newVitals.weight = vitalsGroup.get("Weight")?.value

      if (this.patient.diagnoses![-1]){
        this.diagnosis = this.patient.diagnoses![-1]
        this.diagnosis.vitals = this.newVitals
      }
      
      this.PatientAPI.Update(this.patient.id, this.patient)
    }
  }
}
