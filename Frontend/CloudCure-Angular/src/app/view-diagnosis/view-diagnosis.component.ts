import { ConditionalExpr } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { Patient } from '../AngularModels/Patient';
import { DiagnosisService } from '../services/diagnosis.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-view-diagnosis',
  templateUrl: './view-diagnosis.component.html',
  styleUrls: ['./view-diagnosis.component.css']
})
export class ViewDiagnosisComponent implements OnInit {

  doctorDiagnosis: FormGroup = new FormGroup({
    diagnosis: new FormControl("", Validators.required),
    treatment: new FormControl("", Validators.required),
    isFinalized: new FormControl(true)
  })
  get diagnosis() { return this.doctorDiagnosis.get("diagnosis"); }
  get treatment() { return this.doctorDiagnosis.get("treatment"); }
  get isFinalized() { return this.doctorDiagnosis.get("IsFinalized"); }

  patient: Patient = {} as Patient;
  diagnosisId: number = 0;
  currentDiagnosis: Diagnosis = {} as Diagnosis;

  viewConditions: boolean = false;
  viewAllergies: boolean = false;
  viewSurgeries: boolean = false;
  viewMedication: boolean = false;
  viewDiagnoses: boolean = false;

  constructor(private DiagnosisApi: DiagnosisService, private PatientApi: PatientService, private route: ActivatedRoute, private router: Router) { 
    this.PatientApi.GetById(this.PatientApi.currentPatientId).subscribe(result => {
      this.patient = result
      console.log(this.patient);
      this.diagnosisId = this.patient.diagnoses![this.patient.diagnoses!.length - 1].id
      
      this.DiagnosisApi.GetbyId(this.diagnosisId).subscribe(element => {
        this.currentDiagnosis = element
        console.log("currDiag", this.currentDiagnosis)
      })
    })
  }

  ngOnInit(): void {
  }

  submit(doctorDiagnosis: FormGroup) {

    if (doctorDiagnosis.valid) {
      this.currentDiagnosis.doctorDiagnosis = doctorDiagnosis.get("diagnosis")?.value,
      this.currentDiagnosis.recommendedTreatment = doctorDiagnosis.get("treatment")?.value,
      this.currentDiagnosis.isFinalized = true
      
      this.DiagnosisApi.Update(this.diagnosisId, this.currentDiagnosis).subscribe(result => {
        this.currentDiagnosis = result
        this.router.navigateByUrl("patient-view");
      })
    }
    else {
      this.doctorDiagnosis.markAllAsTouched();
    }
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
