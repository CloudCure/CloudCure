import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

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

  

  bodyparts: Clickable[] = [
    {
      name: 'Right Lung',
      x: 82,
      y: 111,
      width: 28,
      height: 62
    },{
      name: 'Left Lung',
      x: 122,
      y: 107,
      width: 28,
      height: 62
    },{
      name: 'Throat',
      x: 105,
      y: 62,
      width: 20,
      height: 20
    },{
      name: 'Esophagus',
      x: 110,
      y: 82,
      width: 9,
      height: 36
    },{
      name: 'Diaphragm',
      x: 88,
      y: 169,
      width: 58,
      height: 17
    },{
      name: 'Liver',
      x: 85,
      y: 186,
      width: 40,
      height: 27
    },{
      name: 'Stomach',
      x: 120,
      y: 190,
      width: 28,
      height: 32
    },{
      name: 'Large Intestine',
      x: 82,
      y: 237,
      width: 71,
      height: 52
    },{
      name: 'Small Intestine',
      x: 96,
      y: 250,
      width: 45,
      height: 33
    },{
      name: 'Skull',
      x: 353,
      y: 17,
      width: 43,
      height: 68
    },{
      name: 'Left Pectoral',
      x: 645,
      y: 113,
      width: 37,
      height: 53
    },{
      name: 'Right Pectoral',
      x: 593,
      y: 113,
      width: 37,
      height: 53
    }
  ]

  constructor(){
    this.canEdit = false;
  }

  ngOnInit(): void {
  }


  getBodyPartStyle(bodypart: Clickable): object {
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

export class Clickable {
  //coords: {x: number, y: number}[] = [{x: 0, y: 0}, {x: 100, y: 0}, {x: 100, y: 100}, {x: 0, y: 100}]; 
  //I want polygons, but I don't know how to do that right now
  x: number = 0
  y: number = 0
  width: number = 100
  height: number = 100
  name?: string

  constructor(init?: Partial<Clickable>) {
    Object.assign(this, init);
  }
}
