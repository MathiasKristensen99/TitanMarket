import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {ProductList} from "../shared/product-list.model";
import {ProductsService} from "../shared/products.service";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  $products: Observable<ProductList> | undefined

  constructor(private _productService: ProductsService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.$products = this._productService.getProducts()
  }

  searchProducts(name: string): void {
    this.$products = this._productService.searchProducts(name);
  }

}
