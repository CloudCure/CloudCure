import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  display: boolean = false;
  
  @Input('medications') medications: string[] = [''];

  @Output('medications') medicationsChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }

}
