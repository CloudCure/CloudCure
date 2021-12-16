import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent implements OnInit {

  @Input('boxes') boxes: string[];

  
  @Output('boxes') boxesChange = new EventEmitter<string[]>();

  constructor() { 
    this.boxes = [''];
  }

  ngOnInit(): void {
  }

  addOne() {
    this.boxes.push("");
  }
  
  deleteOne(i:number) {
    this.boxes.splice(i,1); 
  }

  boxesChanged() {
    this.boxesChange.emit(this.boxes);
  }

}
