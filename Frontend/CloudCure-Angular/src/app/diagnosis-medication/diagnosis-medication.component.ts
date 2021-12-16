import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Medication } from '../AngularModels/Medication';


@Component({
  selector: 'diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  display: boolean = false;

  @Input('medications') medications: Medication[] = [];

  @Output('medications') medicationsChange = new EventEmitter<Medication[]>();

  constructor() { }

  ngOnInit(): void {
  }

}
