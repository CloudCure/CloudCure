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
  i: number = 0;
  
  constructor() { }

  ngOnInit(): void {
  }

  addFields()
  {
    let number = (<HTMLInputElement>document.getElementById("member"))?.value;
    console.log(number)
    let container = document.getElementById("container");
    let Numb: number = +number;
    console.log(Numb)

    // while (container?.hasChildNodes()) {
    //   container.removeChild(container.lastChild);
    // }
    for (this.i<Numb;this.i++;)
    {
      container?.appendChild(document.createTextNode("Member "+ (this.i+1)));
      let input = document.createElement("input");
      input.type = "text";
      input.name = "member" + this.i;
      container?.appendChild(input);
      container?.appendChild(document.createElement("br"));
    }
  }

}
