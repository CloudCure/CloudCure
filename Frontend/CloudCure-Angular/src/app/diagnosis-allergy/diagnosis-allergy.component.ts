import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'diagnosis-allergy',
  templateUrl: './diagnosis-allergy.component.html',
  styleUrls: ['./diagnosis-allergy.component.css']
})
export class DiagnosisAllergyComponent implements OnInit {
  
  display: boolean = false;
  
  @Input('allergies') allergies: string[] = [''];

  @Output('allergies') allergiesChange = new EventEmitter<string[]>();
  
  constructor() { }

  ngOnInit(): void {
  }

}
