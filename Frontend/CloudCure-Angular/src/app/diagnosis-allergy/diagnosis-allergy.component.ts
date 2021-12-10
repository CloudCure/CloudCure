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
  displayNumber: number = 0;
  
  constructor() { }

  ngOnInit(): void {
  }

  // will hopefully add one more text box
  addBoxes()
  {
    this.displayNumber = this.displayNumber + 1;
  }

  // will hopefully subtract one less text box
  subBoxes()
  {
    if (this.displayNumber = 0) {
      this.displayNumber = this.displayNumber;
    }
    else
    {
      this.displayNumber = this.displayNumber - 1;
    }
  }

}
