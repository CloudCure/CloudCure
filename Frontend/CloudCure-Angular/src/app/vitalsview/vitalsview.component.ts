import { Component, Input, OnInit } from '@angular/core';
import { PatientService } from '../services/patient.service';
import { VitalsService } from '../services/vitals.service';

@Component({
  selector: 'app-vitalsview',
  templateUrl: './vitalsview.component.html',
  styleUrls: ['./vitalsview.component.css']
})
export class VitalsviewComponent implements OnInit {

  //vitalsExists: Boolean = true;
  VitalsId:        any = '';
  // @Input() PatientId:       any = '';
  Systolic:        any = '';
  Diastolic:       any = '';
  OxygenSat:       any = '';
  HeartRate:       any = '';
  Temperature:     any = '';
  RespiratoryRate: any = '';
  Height:          any = '';
  Weight:          any = '';
  EncounterDate:   any = '';

  @Input()
  PatientId:number=0;
  ConditionName?:string;
  listOfVitals:any[]=[];

  constructor(private vitalsApi: VitalsService, private patientApi: PatientService) {
    this.vitalsApi.GetByPatientId(this.patientApi.currentPatientId).subscribe(response => {
      console.log("accessed1")
      console.log(response)
      response.forEach(element =>
        {
          this.listOfVitals.push(element);
        });
    

    })

   }

  ngOnInit(): void {
  }

}
