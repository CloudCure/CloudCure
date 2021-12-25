import { Component, Input, OnInit } from '@angular/core';

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
  listOfMedications:any[]=[];

  constructor() { }

  ngOnInit(): void {
  }

}
