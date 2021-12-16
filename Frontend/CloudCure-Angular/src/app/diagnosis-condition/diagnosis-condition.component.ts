import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Condition } from '../AngularModels/Condition';

@Component({
  selector: 'diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  display: boolean = false;
  
  condition_names: string[] = ['Asthma', 'Cancer', 'Diabetes', 'Heart Disease', 'High Blood Pressure', 'High Cholesterol', 'Kidney Disease', 'Liver Disease', 'Stroke', 'Thyroid Disease'];

  @Input('conditions') conditions: Condition[]|undefined = [];

  @Output('conditions') conditionsChange = new EventEmitter<Condition[]>();

  constructor() { 
    this.conditions = [];
  }

  ngOnInit(): void {
  }



}
