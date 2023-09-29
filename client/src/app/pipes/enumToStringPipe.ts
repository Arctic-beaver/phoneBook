import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enumToString'
})
export class EnumToStringPipe implements PipeTransform {
  transform(value: number, enumObject: any): string {
    const enumKey = Object.keys(enumObject).find(key => enumObject[key] === value);
    return enumKey || 'Неизвестное значение';
  }
}
