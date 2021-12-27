import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    // Custom Pipe that will convert a string that either looks like
    // 'XXX-XXX-XXXX' or 'XXXXXXXXXX' to be '(XXX) XXX-XXXX'
    if (value.includes('-'))
    {
      value = value.split('-').join('');
    }
    if (value.match(/[^0-9]/)) {
      return value;
    }
    
    let areaCode, middleThree, lastFour;
    areaCode = value.slice(0, 3);
    middleThree = value.slice(3, 6);
    lastFour = value.slice(6);

    return `(${areaCode}) ${middleThree}-${lastFour}`;
  }

}
