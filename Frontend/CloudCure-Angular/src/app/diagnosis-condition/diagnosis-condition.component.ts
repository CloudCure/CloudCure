import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  display: boolean = false;
  
  @Input('conditions') conditions: string[] = [''];

  @Output('conditions') conditionsChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }



}
