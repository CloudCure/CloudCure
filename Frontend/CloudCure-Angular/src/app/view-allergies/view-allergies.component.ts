import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-allergies',
  templateUrl: './view-allergies.component.html',
  styleUrls: ['./view-allergies.component.css']
})
export class ViewAllergiesComponent implements OnInit {

  @Input()
  PatientId:number=0;
  ConditionName?:string;
  @Input()
  listOfAllergies:any[]=[];

  constructor() { }

  ngOnInit(): void {
  }

}
