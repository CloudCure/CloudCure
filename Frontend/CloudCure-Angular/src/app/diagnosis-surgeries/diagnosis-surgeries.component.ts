import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Surgery } from '../AngularModels/Surgery';


@Component({
  selector: 'diagnosis-surgeries',
  templateUrl: './diagnosis-surgeries.component.html',
  styleUrls: ['./diagnosis-surgeries.component.css']
})
export class DiagnosisSurgeriesComponent implements OnInit {

  display: boolean = false;

  surgery_names:string[] = ['appendectomy', ''];

  @Input('surgeries') surgeries: Surgery[]|undefined = [];

  @Output('surgeries') surgeriesChange = new EventEmitter<Surgery[]>();

  constructor() { 
    this.surgeries = [];
  }

  ngOnInit(): void {
  }

}
