import { Component, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent implements OnInit {

  // I'm not sure how Input and Output works but I think it needs to be implemented to properly
  // connect the components to the text box components
  @Input()
  canEdit:boolean

  @Output()
  canClick:boolean

  boxes:string[] = [''];
  
  constructor() { 
    this.canEdit = false;
    this.canClick = false;
  }

  ngOnInit(): void {
  }

  addOne() {
    this.boxes.push("");
  }
  
  deleteOne(i:number) {
    this.boxes.splice(i,1); 
  }

}
