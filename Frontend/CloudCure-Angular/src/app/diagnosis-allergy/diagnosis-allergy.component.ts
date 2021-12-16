import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Allergy } from '../AngularModels/Allergy';

@Component({
  selector: 'diagnosis-allergy',
  templateUrl: './diagnosis-allergy.component.html',
  styleUrls: ['./diagnosis-allergy.component.css']
})
export class DiagnosisAllergyComponent implements OnInit {
  
  display: boolean = false;

  allergy_names:string[] = ['Treenuts', 'Iodine', ''];

  @Input('allergies') allergies: Allergy[]|undefined = [];

  @Output('allergies') allergiesChange = new EventEmitter<Allergy[]>();
  
  constructor() { 
    this.allergies = [];
  }

  ngOnInit(): void {
  }

}
