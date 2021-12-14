import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  display: boolean = false;
  medication: string[] = [''];

  constructor() { }

  ngOnInit(): void {
  }

}
