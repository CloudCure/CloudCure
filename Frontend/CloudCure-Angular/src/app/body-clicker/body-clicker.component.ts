import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Clickable } from '../AngularModels/BodyParts';

@Component({
  selector: 'body-clicker',
  templateUrl: './body-clicker.component.html',
  styleUrls: ['./body-clicker.component.scss']
})

export class BodyClickerComponent implements OnInit {

  @Input()
  canEdit: boolean

  @Output('onClick')
  onClick: EventEmitter<Clickable> = new EventEmitter();

  constructor(){
    this.canEdit = false;
  }

  ngOnInit(): void {
  }


  getAreaStyle(bodypart: Clickable): object { //change to polynomial style when ready
    return {
      top: `${bodypart.y}px`,
      left: `${bodypart.x}px`,
      height: `${bodypart.height}px`,
      width: `${bodypart.width}px`
    };
  }

  onAreaClick(bodypart: Clickable) {
    this.onClick.emit(bodypart);
  }

  onAreaContext(e: MouseEvent, bodypart: Clickable) {
    if(bodypart){console.log('editing')}
    else{console.log('creating')}
    e.stopPropagation();
    return false;
  }

  onAreaCreate(x: number, y: number): Clickable {
    const bodypart = new Clickable({x, y, width: 100, height: 100});
    return bodypart
  }

  onAreaEdit(bodypart: Clickable): Clickable {
    return bodypart;
  }

}
