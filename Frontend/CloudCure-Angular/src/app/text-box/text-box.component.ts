import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent implements OnInit {

  @Input('boxes') boxes: string[];

  //////////////////////// testing////////////////////////////
  @Input() public state: string;
  public fromChild="is this working";

  @Output() event: EventEmitter<string[]> = new EventEmitter();
  // textEvent: EventEmitter<string[]> = new EventEmitter<string[]>();
  sendToParent(){
    console.log("Button pushed")
    // this.event.emit(this.fromChild)
    // this.textEvent.emit(this.boxes)
    this.event.emit(this.boxes);
    console.log(this.boxes)
  }
  /////////////////////////////////////////////////////////////

  @Output('boxes') boxesChange = new EventEmitter<string[]>();

  
  constructor() { 
    this.boxes = [''];
    this.state = "";
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
    console.log(this.boxes)
  }

    customTrackBy(index: number, obj: any): any {
         return index;
     }
}
