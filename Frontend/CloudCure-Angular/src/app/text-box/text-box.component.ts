import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent implements OnInit {

  @Input('boxes') boxes: string[];
  @Output('boxes') boxesEmitter = new EventEmitter<string[]>();

  
  constructor() { 
    this.boxes = [''];
  }

  ngOnInit(): void {}
  
  addOne() {this.boxes.push("");}
    
  deleteOne(i:number) {this.boxes.splice(i,1); }
    
  boxesChanged() {
    this.boxesEmitter.emit(this.boxes);
    console.log(this.boxes)
  }

  customTrackBy(index: number, obj: any): any { return index; }
    
  sendToParent(){
    this.boxesEmitter.emit(this.boxes);
    console.log(this.boxes)
  }
}
