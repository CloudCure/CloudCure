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

  @Input('conditions') conditions: Condition[] = [];

  @Output('conditions') conditionsChange = new EventEmitter<Condition[]>();

  constructor() { }

  ngOnInit(): void {
  }



}
