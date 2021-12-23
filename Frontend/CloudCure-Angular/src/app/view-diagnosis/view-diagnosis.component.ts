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

  constructor(private DiagnosisApi : DiagnosisService, private PatientApi : PatientService) { }

  CurrentPatient: number | undefined = this.PatientApi.currentPatientId 
  patient : Patient = {} as Patient;
  //VitalsTest: any = this.patient.vitalHistory?[-1]
  //AssesmentTest: any = this.patient.assessments?[-1]

  doctorDiagnosis:FormGroup = new FormGroup({
    diagnosis: new FormControl("", Validators.required),
    treatment: new FormControl("", Validators.required),
    EncounterDate: new FormControl(""),
    Patient: new FormControl(""),
    vitals: new FormControl(""),
    Assessment: new FormControl(""),
    DoctorDiagnosis: new FormControl(""),
    RecommendedTreatment: new FormControl(""),
    IsFinalized: new FormControl(true)
  })
  get diagnosis() {return this.doctorDiagnosis.get("diagnosis");}
  get treatment() {return this.doctorDiagnosis.get("treatment");}
  get EncounterDate() {return this.doctorDiagnosis.get("EncounterDate");}
  get Patient() {return this.doctorDiagnosis.get("Patient");}
  get vitals() {return this.doctorDiagnosis.get("vitals");}
  get Assessment() {return this.doctorDiagnosis.get("Assessment");}
  get DoctorDiagnosis() {return this.doctorDiagnosis.get("DoctorDiagnosis");}
  get RecommendedTreatment() {return this.doctorDiagnosis.get("RecommendedTreatment");}
  get IsFinalized() {return this.doctorDiagnosis.get("IsFinalized");}


    ngOnInit(): void {
    this.PatientApi.GetById(this.PatientApi.currentPatientId).subscribe(result => {
      this.patient = result
      console.log(this.patient);
    })
  }

  

  submit(doctorDiagnosis: FormGroup)
  {
  
    if (doctorDiagnosis.valid)
    {
      let diagnosis : Diagnosis = {} as Diagnosis
      
        diagnosis.doctorDiagnosis =  doctorDiagnosis.get("diagnosis")?.value,
        diagnosis.recommendedTreatment = doctorDiagnosis.get("treatment")?.value,
        diagnosis.patient = this.patient,
        diagnosis.assessment = this.patient.assessments![this.patient.assessments!.length-1],
        diagnosis.vitals = this.patient.vitalHistory![this.patient.vitalHistory!.length-1],


        //diagnosis.Patient!.id = this.PatientApi.currentPatientId,
        //diagnosis.vitals = doctorDiagnosis.get("vitals")?.value,
        //diagnosis.Assessment = doctorDiagnosis.get("Assessment")?.value,
        diagnosis.isFinalized = doctorDiagnosis.get("IsFinalized")?.value
      
      console.log(diagnosis);
      this.DiagnosisApi.Add(diagnosis).subscribe(
        (response) => {
          console.log("Patient Added");
          console.log(response);
        }
      )

    }
    else
    {
      this.doctorDiagnosis.markAllAsTouched();
    }
  }
}
