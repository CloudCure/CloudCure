import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  constructor(private DiagnosisApi: DiagnosisService, private PatientApi: PatientService) { }

  CurrentPatient: number | undefined = this.PatientApi.currentPatientId
  patient: Patient = {} as Patient;
  currentDiagnosis : Diagnosis = {} as Diagnosis;

  doctorDiagnosis: FormGroup = new FormGroup({
    diagnosis: new FormControl("", Validators.required),
    treatment: new FormControl("", Validators.required),
    isFinalized: new FormControl(true)
  })
  get diagnosis() { return this.doctorDiagnosis.get("diagnosis"); }
  get treatment() { return this.doctorDiagnosis.get("treatment"); }
  get isFinalized() { return this.doctorDiagnosis.get("IsFinalized"); }


  ngOnInit(): void {
    this.PatientApi.GetById(this.PatientApi.currentPatientId).subscribe(result => {
      this.patient = result
      console.log(this.patient);
    })
  }

  submit(doctorDiagnosis: FormGroup) {

    if (doctorDiagnosis.valid) {
      this.currentDiagnosis.id = this.patient.diagnoses![-1].id
      this.currentDiagnosis.doctorDiagnosis = doctorDiagnosis.get("diagnosis")?.value,
      this.currentDiagnosis.recommendedTreatment = doctorDiagnosis.get("treatment")?.value,
      this.currentDiagnosis.isFinalized = doctorDiagnosis.get("IsFinalized")?.value
      
      this.PatientApi.Update(this.patient.id, this.patient);
    }
    else {
      this.doctorDiagnosis.markAllAsTouched();
    }
  }
}
