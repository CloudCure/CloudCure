import { Component, OnInit } from '@angular/core';
import { Clickable } from '../body-clicker/body-clicker.component';

@Component({
  selector: 'app-diagnosis',
  templateUrl: './diagnosis.component.html',
  styleUrls: ['./diagnosis.component.css']
})
export class DiagnosisComponent implements OnInit {

  constructor(){
    this.showBodyClicker = false;
  }

  ngOnInit(): void{

  }

  showBodyClicker: boolean;
  getClick(bodypart: Clickable) {
    console.log(`Clicked on ${bodypart.name}`)
  }

}
