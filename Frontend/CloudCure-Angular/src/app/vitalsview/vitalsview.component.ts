import { Component, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';

@Component({
  selector: 'app-vitalsview',
  templateUrl: './vitalsview.component.html',
  styleUrls: ['./vitalsview.component.css']
})
export class VitalsviewComponent implements OnInit {

  VitalsId:        any = '';
  DiagnosisId:       any = '';
  Systolic:        any = 120;
  Diastolic:       any = 80;
  OxygenSat:       any = 98;
  HeartRate:       any = 75;
  Temperature:     any = 98;
  RespiratoryRate: any = 15;
  Height:          any = 72;
  Weight:          any = 185;
  EncounterDate:   any = '';

  patient: Patient = {} as Patient

  constructor(private vitalsApi: VitalsService, private patientApi: PatientService) {
    this.patientApi.GetById(this.patientApi.currentPatientId).subscribe(result => {
      this.patient = result;
      this.DiagnosisId = this.patient.diagnoses![this.patient.diagnoses!.length - 1].id
    })
    this.vitalsApi.GetByPatientId(this.patient.id).subscribe(response => {
      console.log("accessed1")
      console.log(response)
    
      // this.Systolic =        response.systolic
      // this.Diastolic =       response.diastolic
      // this.OxygenSat =       response.oxygenSat
      // this.HeartRate =       response.heartRate
      // this.Temperature =     response.temperature
      // this.RespiratoryRate = response.respiratoryRate
      // this.Height =          response.height
      // this.Weight =          response.weight
      // this.EncounterDate =   response.encounterDate

    })

   }

  ngOnInit(): void {
  }

}
