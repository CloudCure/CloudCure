import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TextBoxComponent } from '../text-box/text-box.component';

@Component({
  selector: 'app-diagnosis-allergy',
  templateUrl: './diagnosis-allergy.component.html',
  styleUrls: ['./diagnosis-allergy.component.css']
})
export class DiagnosisAllergyComponent implements OnInit {

  //variables
  display: boolean = false;
  allergies: string[] = [''];
  
  constructor() { }

  ngOnInit(): void {
  }

}
