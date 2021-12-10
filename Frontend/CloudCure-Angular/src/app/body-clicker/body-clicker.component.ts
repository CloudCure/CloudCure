import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Clickable } from '../AngularModels/Clickable';

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


  
  bodyparts: Clickable[] = [
  {
    name: 'Right Lung',     //Internal Organs
    x: 78,
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
    x: 85,
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
    x: 80,
    y: 237,
    width: 71,
    height: 52
  },{
    name: 'Small Intestine',
    x: 93,
    y: 250,
    width: 45,
    height: 33
  },{
    name: 'Brain',
    x: 92,
    y: 16,
    width: 44,
    height: 41
  },{
    name: 'Heart',
    x: 101,
    y: 120,
    width: 29,
    height: 32
  },{ 
    name: 'Rectum',
    x: 109,
    y: 289,
    width: 15,
    height: 18
  },{  
    name: 'Skull',          //Skeleton
    x: 353,
    y: 17,
    width: 43,
    height: 68
  },{ 
    name: 'Left Pectoral',  //Muscles front
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
  },{
    name: 'Left Deltoid',
    x: 683,
    y: 109,
    width: 33,
    height: 33
  },{
    name: 'Right Deltoid',
    x: 565,
    y: 109,
    width: 33,
    height: 33
  },{
    name: 'Left Biceps',
    x: 688,
    y: 150,
    width: 28,
    height: 48
  },{
    name: 'Right Biceps',
    x: 562,
    y: 150,
    width: 28,
    height: 48
  },{
    name: 'Left Obliques',
    x: 666,
    y: 163,
    width: 22,
    height: 83
  },{
    name: 'Right Obliques',
    x: 594,
    y: 163,
    width: 22,
    height: 83
  },{
    name: 'Left Quadriceps',
    x: 647,
    y: 272,
    width: 45,
    height: 102
  },{
    name: 'Right Quadriceps',
    x: 587,
    y: 272,
    width: 45,
    height: 102
  },{
    name: 'Right Brachioradialis',
    x: 544,
    y: 200,
    width: 16,
    height: 38
  },{
    name: 'Right Inner Elbow',
    x: 558,
    y: 200,
    width: 16,
    height: 15
  },{
    name: 'Right Flexor',
    x: 558,
    y: 212,
    width: 15,
    height: 35
  },{
    name: 'Right Inner Wrist',
    x: 532,
    y: 259,
    width: 20,
    height: 18
  },{
    name: 'Right Inner Palm',
    x: 527,
    y: 278,
    width: 22,
    height: 17
  },{
    name: 'Right Inner Thumb',
    x: 512,
    y: 275,
    width: 20,
    height: 15
  },{
    name: 'Right Inner Index',
    x: 517,
    y: 293,
    width: 6,
    height: 22
  },{
    name: 'Right Inner Middle',
    x: 524,
    y: 298,
    width: 6,
    height: 24
  },{
    name: 'Right Inner Ring',
    x: 533,
    y: 300,
    width: 6,
    height: 22
  },{
    name: 'Right Inner Pinky',
    x: 540,
    y: 300,
    width: 6,
    height: 20
  },{
    name: 'Left Brachioradialis',
    x: 722,
    y: 200,
    width: 16,
    height: 38
  },{
    name: 'Left Inner Elbow',
    x: 710,
    y: 200,
    width: 16,
    height: 15
  },{
    name: 'Left Flexor',
    x: 708,
    y: 212,
    width: 15,
    height: 35
  },{
    name: 'Left Inner Wrist',
    x: 732,
    y: 259,
    width: 20,
    height: 18
  },{
    name: 'Left Inner Palm',
    x: 729,
    y: 274,
    width: 22,
    height: 17
  },{
    name: 'Left Inner Thumb',
    x: 749,
    y: 273,
    width: 20,
    height: 15
  },{
    name: 'Left Inner Index',
    x: 757,
    y: 291,
    width: 6,
    height: 22
  },{
    name: 'Left Inner Middle',
    x: 751,
    y: 293,
    width: 6,
    height: 24
  },{
    name: 'Left Inner Ring',
    x: 743,
    y: 293,
    width: 6,
    height: 22
  },{
    name: 'Left Inner Pinky',
    x: 735,
    y: 296,
    width: 6,
    height: 20
  },{
    name: 'Upper Abs',
    x: 613,
    y: 157,
    width: 53,
    height: 39
  },{
    name: 'Lower Abs',
    x: 613,
    y: 199,
    width: 55,
    height: 77
  },{
    name: 'Right Kneecap',
    x: 600,
    y: 379,
    width: 35,
    height: 37
  },{
    name: 'Left Kneecap',
    x: 646,
    y: 379,
    width: 35,
    height: 37
  }]
  
}
