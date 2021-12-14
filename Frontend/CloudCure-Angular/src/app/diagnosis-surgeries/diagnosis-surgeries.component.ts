import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'diagnosis-surgeries',
  templateUrl: './diagnosis-surgeries.component.html',
  styleUrls: ['./diagnosis-surgeries.component.css']
})
export class DiagnosisSurgeriesComponent implements OnInit {

  display: boolean = false;
  surgeries: string[] = [''];

  constructor() { }

  ngOnInit(): void {
  }

}
