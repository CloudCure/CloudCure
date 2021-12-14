import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  conditions: string[] = [''];
  
  constructor() { }

  ngOnInit(): void {
  }



}
