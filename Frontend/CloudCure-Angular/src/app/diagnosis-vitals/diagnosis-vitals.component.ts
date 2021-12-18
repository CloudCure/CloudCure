import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VirtualAction } from 'rxjs';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';

@Component({
  selector: 'diagnosis-vitals',
  templateUrl: './diagnosis-vitals.component.html',
  styleUrls: ['./diagnosis-vitals.component.css']
})
export class DiagnosisVitalsComponent implements OnInit {

  // patient ID should be a dynamic input that is recieved from somewhere else
  // I am using 2 for now since I know there is a patient ID of 2 in the DB
  // but it should change depending on what patient is being assessed
  patientId:number = 2;

  // makes the form group for our vitals
  vitalsGroup:FormGroup = new FormGroup({
    Systolic:        new FormControl("", Validators.required),
    Diastolic:       new FormControl("", Validators.required),
    OxygenSat:       new FormControl("", Validators.required),
    HeartRate:       new FormControl("", Validators.required),
    Temperature:     new FormControl("", Validators.required),
    RespiratoryRate: new FormControl("", Validators.required),
    Height:          new FormControl("", Validators.required),
    Weight:          new FormControl("", Validators.required),
  });

  constructor(private VitalsAPI:VitalsService, private PatientAPI:PatientService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    // this way has worked in the past
    // depends on how we wish to implement Patient ID in the routing
    // this.patientId = Number(this.route.snapshot.paramMap.get("id"))
  }

  // function that runs on form submission
  RegisterVitals(vitalsGroup: FormGroup)
  {
    // logs the form
    console.log("register complete")
    console.log(vitalsGroup)

    // checks to see if form is valid
    if (vitalsGroup.valid) {
      let VitalsInfo: Vitals = {
        PatientId: this.patientId,
        Systolic:        vitalsGroup.get("Systolic")?.value,
        Diastolic:       vitalsGroup.get("Diastolic")?.value,
        OxygenSat:       vitalsGroup.get("OxygenSat")?.value,
        HeartRate:       vitalsGroup.get("HeartRate")?.value,
        Tempature:     vitalsGroup.get("Temperature")?.value,
        RespiratoryRate: vitalsGroup.get("RespiratoryRate")?.value,
        Height:          vitalsGroup.get("Height")?.value,
        Weight:          vitalsGroup.get("Weight")?.value,
      }

      // logs if valid
      console.log("Vital info created")
      console.log(VitalsInfo)

      // logs and adds to database
      this.VitalsAPI.Add(VitalsInfo).subscribe(
        (respone) => {
          console.log("Vitals added");
          console.log(respone);
        }
      )
    }

    // Can include routing to next page here too
  }

}
