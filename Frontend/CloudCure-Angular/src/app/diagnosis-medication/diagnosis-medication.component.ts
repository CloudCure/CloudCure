import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  display: boolean = false;
  medications: string[] = [''];

  constructor() { }

  ngOnInit(): void {
  }

}
