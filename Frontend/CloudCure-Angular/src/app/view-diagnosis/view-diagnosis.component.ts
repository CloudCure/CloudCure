import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DiagnosisService } from '../services/diagnosis.service';

@Component({
  selector: 'app-view-diagnosis',
  templateUrl: './view-diagnosis.component.html',
  styleUrls: ['./view-diagnosis.component.css']
})
export class ViewDiagnosisComponent implements OnInit {

  constructor(private DiagnosisApi : DiagnosisService) { }

  doctorDiagnosis:FormGroup = new FormGroup({
    diagnosis: new FormControl("", Validators.required),
    treatment: new FormControl("", Validators.required),
    EncounterDate: new FormControl("", Validators.required),
    Patient: new FormControl("", Validators.required),
    vitals: new FormControl("", Validators.required),
    Assessment: new FormControl("", Validators.required),
    DoctorDiagnosis: new FormControl("", Validators.required),
    RecommendedTreatment: new FormControl("", Validators.required),
    IsFinalized: new FormControl("", Validators.required)
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
  }

  submit(doctorDiagnosis: FormGroup)
  {
  
    if (doctorDiagnosis.valid)
    {
      let diagnosis =
      {
        diagnosis: doctorDiagnosis.get("diagnosis")?.value,
        treatment: doctorDiagnosis.get("treatment")?.value,
        EncounterDate : doctorDiagnosis.get("EncounterDate")?.value,
        Patient : doctorDiagnosis.get("Patient")?.value,
        vitals : doctorDiagnosis.get("vitals")?.value,
        Assessment : doctorDiagnosis.get("Assessment")?.value,
        DoctorDiagnosis : doctorDiagnosis.get("DoctorDiagnosis")?.value,
        RecommendedTreatment : doctorDiagnosis.get("RecommendedTreatment")?.value,
        IsFinalized : doctorDiagnosis.get("IsFinalized")?.value
      }
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
