import { Component, Input, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';

@Component({
  selector: 'app-view-surgeries',
  templateUrl: './view-surgeries.component.html',
  styleUrls: ['./view-surgeries.component.css']
})
export class ViewSurgeriesComponent implements OnInit {

  // @Input()
  // PatientId:number=0;
  // ConditionName?:string;
  @Input()
  listOfSurgeries?:any[]=[];
  @Input()
  item: Patient = {} as Patient
  constructor() { }

  ngOnInit(): void {
    this.listOfSurgeries=this.item.surgeries;
  }

}
