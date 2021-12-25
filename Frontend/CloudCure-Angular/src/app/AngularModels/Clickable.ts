export class Clickable {
  //coords: {x: number, y: number}[] = [{x: 0, y: 0}, {x: 100, y: 0}, {x: 100, y: 100}, {x: 0, y: 100}]; 
  //I want polygons that perfectly match the picture, but I don't know how to do that right now
  x: number = 0
  y: number = 0
  width: number = 100
  height: number = 100
  name?: string
  active? : boolean

  constructor(init?: Partial<Clickable>) {
    Object.assign(this, init);
  }
}