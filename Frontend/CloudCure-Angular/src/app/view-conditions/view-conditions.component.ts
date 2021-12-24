import { Component, Input, OnInit } from '@angular/core';
import { ConditionService } from '../services/condition.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-view-conditions',
  templateUrl: './view-conditions.component.html',
  styleUrls: ['./view-conditions.component.css']
})
export class ViewConditionsComponent implements OnInit {

  Id?:number;
  // PatientId?:number = this.patientApi.currentPatientId;
  // ConditionName?:string;

  @Input()
  PatientId:number=0;
  ConditionName?:string;
  @Input()
  listOfConditions:any[]=[];

  constructor(private ConditionApi: ConditionService, private patientApi: PatientService) 
  {
    this.ConditionApi.SearchByPatientId(this.PatientId).subscribe(response => {
      console.log("accessed1")
      console.log(response)

    // this.PatientId = response.PatientId
    // this.ConditionName = response.ConditionName
    })

    
  }

  ngOnInit(): void {
  }

}
