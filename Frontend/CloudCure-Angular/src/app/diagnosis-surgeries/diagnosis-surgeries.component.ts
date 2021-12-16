import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';


@Component({
  selector: 'diagnosis-surgeries',
  templateUrl: './diagnosis-surgeries.component.html',
  styleUrls: ['./diagnosis-surgeries.component.css']
})
export class DiagnosisSurgeriesComponent implements OnInit {

  display: boolean = false;

  @Input('surgeries') surgeries: string[] = [''];

  @Output('surgeries') surgeriesChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }

}
