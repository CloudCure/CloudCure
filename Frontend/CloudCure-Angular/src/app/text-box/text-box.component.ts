import { Component, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-text-box',
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

<<<<<<< HEAD
  boxes:string[] = [''];
=======
  boxes:string[] = [];
>>>>>>> 4bcca969062716384dea2adb43539ca16aab034a
  
  constructor() { 
    this.canEdit = false;
    this.canClick = false;
  }

  ngOnInit(): void {
  }

  addOne() {
    this.boxes.push("");
  }
<<<<<<< HEAD
  
  deleteOne(i:number) {
    this.boxes.splice(i,1); 
=======

  subOne() {
    this.boxes.pop();
>>>>>>> 4bcca969062716384dea2adb43539ca16aab034a
  }

}
