import { Pipe, PipeTransform } from '@angular/core';
import { EPharmaType } from 'src/app/pharmaceuticals/interfaces/enums.interface';

@Pipe({
  name: 'epharmaTypeClass'
})
export class EpharmaTypeClassPipe implements PipeTransform {

  transform(type: EPharmaType): string {
    switch(type) {
      case EPharmaType.Analgesico:
        return 'bg-gray-600/10 text-gray-600';
      case EPharmaType.Anestesico:
        return 'bg-amber-600/10 text-amber-600';
      case EPharmaType.Ansiolitico:
        return 'bg-blue-600/10 text-blue-600';
      case EPharmaType.Antibiotico:
        return 'bg-orange-600/10 text-orange-600';
      case EPharmaType.Anticolinergico:
        return 'bg-green-600/10 text-green-600';
      default:
          return 'black';
    }
  }

}
