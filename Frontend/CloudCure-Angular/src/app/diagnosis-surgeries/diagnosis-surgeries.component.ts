import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-diagnosis-surgeries',
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
