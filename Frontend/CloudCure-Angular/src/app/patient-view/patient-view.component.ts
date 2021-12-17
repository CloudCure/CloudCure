import { Component, OnInit } from '@angular/core';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {

  patientExists: Boolean = true;
  
  PatientId:          any;
  PatientName:        string | undefined = 'Timmy';
  PatientPhone:       any = '';
  PatientAddress:     any = '';
  DateOfBirth:        any = '';
  Conditions:         any = [];
  Allergies:          any = [];
  Surgeries:          any = [];
  CurrentMedications: any = [];
  VitalHistory:       any = [];
  Assessments:        any = [];

  constructor(private patientApi: PatientService) {
    //1 will be changed later
    this.patientApi.GetById(1).subscribe(response => {
      this.patientExists = true;

      this.PatientName = response.PatientName
      this.PatientPhone = response.PatientPhone
      this.PatientAddress = response.PatientAddress
      this.DateOfBirth = response.DateOfBirth
      this.Conditions = response.Conditions

    })
   }

  ngOnInit(): void {
  }

}
