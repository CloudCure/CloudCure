import { Component, Input, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';

@Component({
  selector: 'app-view-medications',
  templateUrl: './view-medications.component.html',
  styleUrls: ['./view-medications.component.css']
})
export class ViewMedicationsComponent implements OnInit {

  @Input()
  PatientId:number=0;
  ConditionName?:string;
  @Input()
  listOfMedications?:any[]=[];
  @Input()
  item: Patient = {} as Patient
  constructor() { }

  ngOnInit(): void {
    this.listOfMedications=this.item.currentMedications;
  }

}
