import { Component, Input } from '@angular/core';
import { product } from 'src/app/shared/Models/product';

@Component({
  selector: 'app-product-items',
  templateUrl: './product-items.component.html',
  styleUrls: ['./product-items.component.scss']
})
export class ProductItemsComponent {
@Input() product?:product;
}
