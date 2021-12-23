import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VirtualAction } from 'rxjs';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';
import { Router } from '@angular/router';
import { AssessmentService } from '../services/assessement.service';

@Component({
  selector: 'diagnosis-vitals',
  templateUrl: './diagnosis-vitals.component.html',
  styleUrls: ['./diagnosis-vitals.component.css']
})
export class DiagnosisVitalsComponent implements OnInit, OnDestroy {

  // patient ID should be a dynamic input that is recieved from somewhere else
  // I am using 2 for now since I know there is a patient ID of 2 in the DB
  // but it should change depending on what patient is being assessed
  patientId:number|undefined = 0;

  // makes the form group for our vitals
  vitalsGroup:FormGroup = new FormGroup({
    Systolic:        new FormControl("", Validators.required),
    Diastolic:       new FormControl("", Validators.required),
    OxygenSat:       new FormControl("", Validators.required),
    HeartRate:       new FormControl("", Validators.required),
    Temperature:     new FormControl("", Validators.required),
    RespiratoryRate: new FormControl("", Validators.required),
    Height:          new FormControl("", Validators.required),
    Weight:          new FormControl('', Validators.required),
    Date: new FormControl(new Date().toISOString().split('T')[0], Validators.required)
  });

  OurBoolean!: boolean;
  patient!: Patient
  date: string = new Date().toISOString().split('T')[0];
  constructor(private VitalsAPI:VitalsService,private PatientAPI:PatientService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder) 
  {
    
  }
  
  
  
  ngOnDestroy(): void {
    this.VitalsAPI.submitButton = false;
  }

  ngOnInit(): void {
    this.VitalsAPI.submitButton; 
    this.OurBoolean = this.VitalsAPI.submitButton
    this.OurBoolean = true;
    // this way has worked in the past
    // depends on how we wish to implement Patient ID in the routing
    // this.patientId = Number(this.route.snapshot.paramMap.get("id"))
    this.patientId = this.PatientAPI.currentPatientId;
    this.PatientAPI.GetById(this.patientId).subscribe(
      (response) => {
        console.log(response);
        this.patient = response;
      }
    )
  }

  submit()
  {
    this.OurBoolean = false;
    this.router.navigateByUrl("/profile");
  }

  submitOne()
  {
    this.OurBoolean = false;
    this.router.navigateByUrl("/patient");
  }



  PatientProfile()
  {
    this.router.navigateByUrl("patient-view");
  }

  Assessments()
  {
    this.router.navigateByUrl("/assessment");
  }

  // function that runs on form submission
  RegisterVitals(vitalsGroup: FormGroup)
  {
    // logs the form
    console.log("register complete")
    console.log(vitalsGroup)
    this.OurBoolean = false;

    // checks to see if form is valid
    if (vitalsGroup.valid) {
      let VitalsInfo: Vitals = {
        PatientId: this.patientId,
        systolic:        vitalsGroup.get("Systolic")?.value,
        diastolic:       vitalsGroup.get("Diastolic")?.value,
        oxygenSat:       vitalsGroup.get("OxygenSat")?.value,
        heartRate:       vitalsGroup.get("HeartRate")?.value,
        temperature:     vitalsGroup.get("Temperature")?.value,
        respiratoryRate: vitalsGroup.get("RespiratoryRate")?.value,
        height:          vitalsGroup.get("Height")?.value,
        weight:          vitalsGroup.get("Weight")?.value,
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
