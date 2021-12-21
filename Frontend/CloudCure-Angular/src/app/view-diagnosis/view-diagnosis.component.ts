import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-view-diagnosis',
  templateUrl: './view-diagnosis.component.html',
  styleUrls: ['./view-diagnosis.component.css']
})
export class ViewDiagnosisComponent implements OnInit {

  constructor() { }

  doctorDiagnosis:FormGroup = new FormGroup({
    diagnosis: new FormControl("", Validators.required),
    treatment: new FormControl("", Validators.required)
  })
  get diagnosis() {return this.doctorDiagnosis.get("diagnosis");}
  get treatment() {return this.doctorDiagnosis.get("treatment");}


  ngOnInit(): void {
  }

  submit(doctorDiagnosis: FormGroup)
  {
  
    if (doctorDiagnosis.valid)
    {
      let diagnosis =
      {
        diagnosis: doctorDiagnosis.get("diagnosis")?.value,
        treatment: doctorDiagnosis.get("treatment")?.value
      }
      console.log(diagnosis);
    }
    else
    {
      this.doctorDiagnosis.markAllAsTouched();
    }
  }
}
