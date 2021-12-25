import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Clickable } from '../AngularModels/Clickable';
declare var $: any;


@Component({
  selector: 'body-clicker',
  templateUrl: './body-clicker.component.html',
  styleUrls: ['./body-clicker.component.scss'],
})
export class BodyClickerComponent implements OnInit {
  @Input()
  canEdit: boolean;

  @Output('onClick')
  onClick: EventEmitter<Clickable> = new EventEmitter();
  test:string = '';
  id:number = 0;

  constructor() {
    this.canEdit = false;
  }

  ngOnInit(): void {}

  getAreaStyle(bodypart: Clickable): object {
    //change to polynomial style when ready
    return {
      top: `${bodypart.y}px`,
      left: `${bodypart.x}px`,
      height: `${bodypart.height}px`,
      width: `${bodypart.width}px`,
    };
  }

  onAreaClick(bodypart: Clickable) {

    this.onClick.emit(bodypart);
  }

  onAreaContext(e: MouseEvent, bodypart: Clickable) {
    if (bodypart) {
      console.log('editing');
    } else {
      console.log('creating');
    }
    e.stopPropagation();
    return false;
  }

  createBorder(index:any)
  {
    this.bodyparts[index].active = !this.bodyparts[index].active;
    let result = document.getElementById(index);
    if (this.bodyparts[index].active)
    {
      result?.classList.add('area-clicked');
      result?.classList.remove('area');
    }
    else 
    {
      result?.classList.add('area');
      result?.classList.remove('area-clicked');
    }
    

    console.log(this.bodyparts[index].active);
  }

  onAreaCreate(x: number, y: number): Clickable {
    const bodypart = new Clickable({ x, y, width: 100, height: 100 });
    return bodypart;
  }

  onAreaEdit(bodypart: Clickable): Clickable {
    return bodypart;
  }

  bodyparts: Clickable[] = [
    {
      name: 'Right Lung', //Internal Organs
      x: 78,
      y: 111,
      width: 28,
      height: 62,
    },{
      name: 'Left Lung',
      x: 122,
      y: 107,
      width: 28,
      height: 62,
    },{
      name: 'Throat',
      x: 105,
      y: 62,
      width: 20,
      height: 20,
    },{
      name: 'Esophagus',
      x: 110,
      y: 82,
      width: 9,
      height: 36,
    },{
      name: 'Diaphragm',
      x: 85,
      y: 169,
      width: 58,
      height: 17,
    },{
      name: 'Liver',
      x: 85,
      y: 186,
      width: 40,
      height: 27,
    },{
      name: 'Stomach',
      x: 120,
      y: 190,
      width: 28,
      height: 32,
    },{
      name: 'Large Intestine',
      x: 80,
      y: 237,
      width: 71,
      height: 52,
    },{
      name: 'Small Intestine',
      x: 93,
      y: 250,
      width: 45,
      height: 33,
    },{
      name: 'Brain',
      x: 92,
      y: 16,
      width: 44,
      height: 41,
    },{
      name: 'Heart',
      x: 101,
      y: 120,
      width: 29,
      height: 32,
    },{
      name: 'Rectum',
      x: 109,
      y: 289,
      width: 15,
      height: 18,
    },{
      name: 'Skull', //Skeleton
      x: 353,
      y: 17,
      width: 43,
      height: 46
    },{
      name: 'Mandible',
      x: 359,
      y: 62,
      width: 32,
      height: 20
    },{
      name: 'Left Femur',
      x: 395,
      y: 289,
      width: 24,
      height: 108,
    },{
      name: 'Right Femur',
      x: 330,
      y: 289,
      width: 24,
      height: 108,
    },{
      name: 'Right Knee',
      x: 341,
      y: 397,
      width: 17,
      height: 13,
    },{
      name: 'Left Knee',
      x: 390,
      y: 401,
      width: 17,
      height: 11,
    },{
      name: 'Right Fibula',
      x: 339,
      y: 415,
      width: 10,
      height: 80,
    },{
      name: 'Left Fibula',
      x: 402,
      y: 415,
      width: 10,
      height: 80,
    },{
      name: 'Left Tibia',
      x: 390,
      y: 412,
      width: 10,
      height: 100,
    },{
      name: 'Right Tibia',
      x: 348,
      y: 412,
      width: 10,
      height: 100,
    },{
      name: 'Left Tarsals',
      x: 388,
      y: 515,
      width: 18,
      height: 8
    },{
      name: 'Right Tarsals',
      x: 343,
      y: 515,
      width: 18,
      height: 8
    },{
      name: 'Left Tibia',
      x: 407,
      y: 525,
      width: 17,
      height: 6,
    },{
      name: 'Left Foot',
      x: 388,
      y: 525,
      width: 29,
      height: 36,
    },{
      name: 'Right Foot',
      x: 330,
      y: 522,
      width: 29,
      height: 36,
    },{
      name: 'Right Scapula',
      x: 322,
      y: 115,
      width: 30,
      height: 57,
    },{
      name: 'Left Scapula',
      x: 398,
      y: 115,
      width: 30,
      height: 50,
    },{
      name: 'Right Clavicle',
      x: 324,
      y: 113,
      width: 12,
      height: 3,
    },{
      name: 'Left Clavicle',
      x: 429,
      y: 113,
      width: 26,
      height: 4,
    },{
      name: 'Left Humerus',
      x: 448,
      y: 202,
      width: 14,
      height: 71,
    },{
      name: 'Right Humerus',
      x: 311,
      y: 128,
      width: 14,
      height: 74,
    },{
      name: 'Right Ulna',
      x: 311,
      y: 128,
      width: 16,
      height: 72,
    },{
      name: 'Left Ulna',
      x: 422,
      y: 128,
      width: 16,
      height: 72,
    },{
      name: 'Right Rib',
      x: 342,
      y: 121,
      width: 30,
      height: 85,
    },{
      name: 'Left Rib',
      x: 380,
      y: 121,
      width: 30,
      height: 85,
    },{
      name: 'Right Radius',
      x: 295,
      y: 205,
      width: 21,
      height: 76,
    },{
      name: 'Left Radius',
      x: 433,
      y: 205,
      width: 21,
      height: 76,
    },{
      name: 'Back Bone',
      x: 370,
      y: 98,
      width: 10,
      height: 159,
    },{
      name: 'Right Pelvis',
      x: 335,
      y: 235,
      width: 33,
      height: 44,
    },{
      name: 'Left Pelvis',
      x: 382,
      y: 235,
      width: 33,
      height: 44,
    },{
      name: 'Right Carpals',
      x: 285,
      y: 283,
      width: 18,
      height: 12,
    },{
      name: 'Left Carpals',
      x: 445,
      y: 283,
      width: 18,
      height: 12,
    },{
      name: 'Right Hand',
      x: 272,
      y: 293,
      width: 28,
      height: 40,
    },{
      name: 'Left Hand',
      x: 446,
      y: 293,
      width: 28,
      height: 40
    },{
      name: 'Left Pectoral', //Muscles
      x: 645,
      y: 113,
      width: 37,
      height: 44,
    },{
      name: 'Right Pectoral',
      x: 593,
      y: 113,
      width: 37,
      height: 44,
    },{
      name: 'Left Deltoid',
      x: 683,
      y: 109,
      width: 33,
      height: 33,
    },{
      name: 'Right Deltoid',
      x: 565,
      y: 109,
      width: 33,
      height: 33,
    },{
      name: 'Left Biceps',
      x: 688,
      y: 150,
      width: 28,
      height: 48,
    },{
      name: 'Right Biceps',
      x: 562,
      y: 150,
      width: 28,
      height: 48,
    },{
      name: 'Left Obliques',
      x: 666,
      y: 163,
      width: 22,
      height: 83,
    },{
      name: 'Right Obliques',
      x: 594,
      y: 163,
      width: 22,
      height: 83,
    },{
      name: 'Left Quadriceps',
      x: 647,
      y: 272,
      width: 45,
      height: 102,
    },{
      name: 'Right Quadriceps',
      x: 587,
      y: 272,
      width: 45,
      height: 102,
    },{
      name: 'Right Brachioradialis',
      x: 544,
      y: 200,
      width: 16,
      height: 38,
    },{
      name: 'Right Inner Elbow',
      x: 558,
      y: 200,
      width: 16,
      height: 15,
    },{
      name: 'Right Flexor',
      x: 558,
      y: 212,
      width: 15,
      height: 35,
    },{
      name: 'Right Inner Wrist',
      x: 532,
      y: 259,
      width: 20,
      height: 18,
    },{
      name: 'Right Inner Palm',
      x: 527,
      y: 278,
      width: 22,
      height: 17,
    },{
      name: 'Right Inner Thumb',
      x: 512,
      y: 275,
      width: 20,
      height: 15,
    },{
      name: 'Right Inner Index',
      x: 517,
      y: 293,
      width: 6,
      height: 22,
    },{
      name: 'Right Inner Middle',
      x: 524,
      y: 298,
      width: 6,
      height: 24,
    },{
      name: 'Right Inner Ring',
      x: 533,
      y: 300,
      width: 6,
      height: 22,
    },{
      name: 'Right Inner Pinky',
      x: 540,
      y: 300,
      width: 6,
      height: 20,
    },{
      name: 'Left Brachioradialis',
      x: 722,
      y: 200,
      width: 16,
      height: 38,
    },{
      name: 'Left Inner Elbow',
      x: 710,
      y: 200,
      width: 16,
      height: 15,
    },{
      name: 'Left Flexor',
      x: 708,
      y: 212,
      width: 15,
      height: 35,
    },{
      name: 'Left Inner Wrist',
      x: 732,
      y: 259,
      width: 20,
      height: 18,
    },{
      name: 'Left Inner Palm',
      x: 729,
      y: 274,
      width: 22,
      height: 17,
    },{
      name: 'Left Inner Thumb',
      x: 749,
      y: 273,
      width: 20,
      height: 15,
    },{
      name: 'Left Inner Index',
      x: 757,
      y: 291,
      width: 6,
      height: 22,
    },{
      name: 'Left Inner Middle',
      x: 751,
      y: 293,
      width: 6,
      height: 24,
    },{
      name: 'Left Inner Ring',
      x: 743,
      y: 293,
      width: 6,
      height: 22,
    },{
      name: 'Left Inner Pinky',
      x: 735,
      y: 296,
      width: 6,
      height: 20,
    },{
      name: 'Upper Abs',
      x: 613,
      y: 157,
      width: 53,
      height: 39,
    },{
      name: 'Lower Abs',
      x: 611,
      y: 199,
      width: 55,
      height: 77,
    },{
      name: 'Right Kneecap',
      x: 600,
      y: 379,
      width: 35,
      height: 37,
    },{
      name: 'Left Kneecap',
      x: 646,
      y: 379,
      width: 35,
      height: 37,
    },{
      name: 'Left Outer Hand',
      x: 789,
      y: 270,
      width: 22,
      height: 22,
    },{
      name: 'Left Outer Thumb',
      x: 777,
      y: 271,
      width: 12,
      height: 18,
    },{
      name: 'Right Outer Hand',
      x: 983,
      y: 270,
      width: 22,
      height: 22,
    },{
      name: 'Right Outer Thumb',
      x: 1007,
      y: 271,
      width: 12,
      height: 18,
    },{
      name: 'Left Elbow',
      x: 810,
      y: 200,
      width: 26,
      height: 26,
    },{
      name: 'Right Elbow',
      x: 961,
      y: 202,
      width: 26,
      height: 26,
    },{
      name: 'Left Outer Pinky',
      x: 801,
      y: 295,
      width: 6,
      height: 16,
    },{
      name: 'Left Outer Index',
      x: 777,
      y: 290,
      width: 8,
      height: 22,
    },{
      name: 'Left Outer Middle',
      x: 785,
      y: 292,
      width: 6,
      height: 24,
    },{
      name: 'Left Outer Ring',
      x: 793,
      y: 295,
      width: 6,
      height: 23,
    },{
      name: 'Right Outer Pinky',
      x: 985,
      y: 295,
      width: 6,
      height: 16,
    },{
      name: 'Right Outer Index',
      x: 1007,
      y: 290,
      width: 8,
      height: 22,
    },{
      name: 'Right Outer Middle',
      x: 1001,
      y: 292,
      width: 6,
      height: 24,
    },{
      name: 'Right Outer Ring',
      x: 993,
      y: 295,
      width: 6,
      height: 23,
    },{
      name: 'Left Eye',
      x: 644,
      y: 34,
      width: 10,
      height: 7,
    },{
      name: 'Right Eye',
      x: 625,
      y: 34,
      width: 10,
      height: 7,
    },{
      name: 'Right Ear',
      x: 611,
      y: 42,
      width: 8,
      height: 14,
    },{
      name: 'Left Ear',
      x: 661,
      y: 42,
      width: 8,
      height: 14,
    },{
      name: 'Nose',
      x: 636,
      y: 41,
      width: 7,
      height: 13,
    },{
      name: 'Lips',
      x: 633,
      y: 56,
      width: 13,
      height: 6,
    },{
      name: 'Chin',
      x: 630,
      y: 64,
      width: 18,
      height: 10,
    },{
      name: 'Neck',
      x: 621,
      y: 71,
      width: 37,
      height: 30,
    },{
      name: 'Right Traps',
      x: 904,
      y: 75,
      width: 33,
      height: 106,
    },{
      name: 'Left Traps',
      x: 865,
      y: 75,
      width: 33,
      height: 106,
    },{
      name: 'Right Lats',
      x: 910,
      y: 159,
      width: 33,
      height: 82,
    },{
      name: 'Left Lats',
      x: 852,
      y: 159,
      width: 33,
      height: 82,
    },{
      name: 'Right Buttocks',
      x: 903,
      y: 245,
      width: 45,
      height: 60,
    },{
      name: 'Left Buttocks',
      x: 853,
      y: 245,
      width: 45,
      height: 60,
    },{
      name: 'Left Triceps',
      x: 818,
      y: 153,
      width: 28,
      height: 53,
    },{
      name: 'Right Triceps',
      x: 953,
      y: 153,
      width: 28,
      height: 53,
    },{
      name: 'Left Calf',
      x: 863,
      y: 410,
      width: 34,
      height: 80,
    },{
      name: 'Right Calf',
      x: 905,
      y: 410,
      width: 34,
      height: 80,
    },{
      name: 'Left Shin',
      x: 604,
      y: 423,
      width: 27,
      height: 76,
    },{
      name: 'Right Shin',
      x: 645,
      y: 423,
      width: 27,
      height: 76,
    },{
      name: 'Left Foot',
      x: 600,
      y: 525,
      width: 34,
      height: 43,
    },{
      name: 'Right Foot',
      x: 644,
      y: 525,
      width: 34,
      height: 43,
    },{
      name: 'Left Ankle',
      x: 645,
      y: 511,
      width: 23,
      height: 20,
    },{
      name: 'Right Ankle',
      x: 611,
      y: 511,
      width: 23,
      height: 20,
    },{
      name: 'Left Heel',
      x: 874,
      y: 533,
      width: 25,
      height: 20,
    },{
      name: 'Right Heel',
      x: 905,
      y: 533,
      width: 25,
      height: 20,
    },{
      name: 'Right Hamstring',
      x: 904,
      y: 307,
      width: 38,
      height: 92,
    },{
      name: 'Left Hamstring',
      x: 860,
      y: 307,
      width: 38,
      height: 92,
    },{
      name: 'Right Extensor',
      x: 975,
      y: 214,
      width: 22,
      height: 52,
    },{
      name: 'Left Extensor',
      x: 800,
      y: 214,
      width: 22,
      height: 52,
    }];
}
