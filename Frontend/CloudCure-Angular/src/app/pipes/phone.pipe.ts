import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    // let value = tel.toString().trim().replace(/^\+/, "");
    
    if (value.includes('-'))
    {
      value = value.split('-').join('');
    }
    if (value.match(/[^0-9]/)) {
      return value;
    }
    
    // else if (value.length > 10)
    // {
    //   return value.slice(7);
    // }
    let areaCode, middleThree, lastFour;
    areaCode = value.slice(0, 3);
    middleThree = value.slice(3, 6);
    lastFour = value.slice(6);

    return `(${areaCode}) ${middleThree}-${lastFour}`;
  }

}
