import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'discount'
})
export class DiscountPipe implements PipeTransform {
  transform(price: number, discountPercent: number = 10): number {
    if (price == null || discountPercent == null) {
      return price;
    }

    return price - (price * discountPercent / 100);
  }
}
