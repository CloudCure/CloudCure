import { Component, OnInit } from '@angular/core';
import { Clickable } from '../body-clicker/body-clicker.component';

@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html',
  styleUrls: ['./assessment.component.css']
})
export class AssessmentComponent implements OnInit {

  //variables
  showBodyClicker: boolean = false;
  constructor(){ }

  ngOnInit(): void {
  }

  getClick(bodypart: Clickable) {
    console.log(`Clicked on ${bodypart.name}`)
  }

}
