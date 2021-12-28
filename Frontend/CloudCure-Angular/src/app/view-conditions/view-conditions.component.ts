import { Component, Input, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { ConditionService } from '../services/condition.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-view-conditions',
  templateUrl: './view-conditions.component.html',
  styleUrls: ['./view-conditions.component.css']
})
export class ViewConditionsComponent implements OnInit {

  Id?:number;

  @Input()
  PatientId:number=0;

  ConditionName?:string;

  @Input()
  listOfConditions?:any[]=[];
  
  @Input()
  item: Patient = {} as Patient

  constructor(private ConditionApi: ConditionService, private patientApi: PatientService) 
  {
  }

  ngOnInit(): void {
    this.listOfConditions=this.item.conditions;
  }

}
