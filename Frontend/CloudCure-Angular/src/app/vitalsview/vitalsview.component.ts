import { Component, OnInit } from '@angular/core';
import { VitalsService } from '../services/vitals.service';

@Component({
  selector: 'app-vitalsview',
  templateUrl: './vitalsview.component.html',
  styleUrls: ['./vitalsview.component.css']
})
export class VitalsviewComponent implements OnInit {

  //vitalsExists: Boolean = true;
  VitalsId:       any = '';
  PatientId:       any = '';
  Systolic:        any = '';
  Diastolic:       any = '';
  OxygenSat:       any = '';
  HeartRate:       any = '';
  Tempature:     any = '';
  RespiratoryRate: any = '';
  Height:          any = '';
  Weight:          any = '';
  EncounterDate:  any = '';

  constructor(private vitalsApi: VitalsService) {
    this.vitalsApi.GetById(1).subscribe(response => {
      console.log("accessed vitals")
      console.log(response)
      //this.vitalsExists = true;
      //Instantiating Vitals Variables
      this.PatientId =        response.PatientId
      this.Systolic =          this.Systolic
      this.Diastolic =           this.Diastolic
      this.OxygenSat =        this.OxygenSat
      this.HeartRate =       this.HeartRate
      this.Tempature =     this.Tempature
      this.RespiratoryRate =        this.RespiratoryRate
      this.Height =         response.Height
      this.Weight =          response.Weight
      this.EncounterDate =          response.EncounterDate

    })
   }

  ngOnInit(): void {
  }

}
