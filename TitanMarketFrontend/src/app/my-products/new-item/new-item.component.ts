import { Component, OnInit } from '@angular/core';
import {CreateProduct} from "../shared/create-product.model";
import {MyProductsService} from "../shared/my-products.service";
import {FormBuilder, FormControl, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-new-item',
  templateUrl: './new-item.component.html',
  styleUrls: ['./new-item.component.scss']
})
export class NewItemComponent implements OnInit {
  productName: string | any;
  productPrice: string | any;

  constructor(private _myProductsService: MyProductsService,
              private _fb: FormBuilder,
              private _router: Router) { }

  ngOnInit(): void {
  }

  submitForSale(productName: string, productPrice: number){
    this._myProductsService.createProduct({Name:productName, Price: productPrice} as CreateProduct).subscribe();
    this.back();
  }

  back(){
    this._router.navigateByUrl("/my-products");
  }
}
