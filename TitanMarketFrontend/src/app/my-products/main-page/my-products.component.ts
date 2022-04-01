import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MyProductsService} from "../shared/my-products.service";
import {Observable} from "rxjs";
import {ProductList} from "../../products/shared/product-list.model";
import {Product} from "../../products/shared/product.model";
import {CreateProduct} from "../shared/create-product.model";

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.scss']
})
export class MyProductsComponent implements OnInit {
  $products: Observable<ProductList> | undefined;
  selectedItem: Product | any;
  newName: any | undefined;
  newPrice: any | undefined;

  constructor(private _router: Router,
              private _activatedRoute:ActivatedRoute,
              private _myProductsService: MyProductsService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  navigateToNewItem(){
    this._router.navigate(["new-item"],{relativeTo:this._activatedRoute});
  }

  getProducts(): void {
    this.$products = this._myProductsService.getMyProducts();
  }

  saveChange(itemToUpdate: number, newName: string, newPrice: number) {
    this._myProductsService.update(itemToUpdate, {name: newName, price: newPrice} as Product).subscribe();
    this.refresh();
  }

  removeProduct(id: number) {
    this._myProductsService.deleteProduct(id).subscribe();
    this.refresh();
  }

  private refresh() {
    window.location.reload();
  }

  getData(){
    const table = document.querySelector('#table');

  }
}
