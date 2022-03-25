import { Component, OnInit } from '@angular/core';
import {CreateProduct} from "../shared/create-product.model";
import {MyProductsService} from "../shared/my-products.service";
import {FormBuilder, FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-new-item',
  templateUrl: './new-item.component.html',
  styleUrls: ['./new-item.component.scss']
})
export class NewItemComponent implements OnInit {
  newProductForm = this._fb.group({
    productName: new FormControl('',
      [Validators.required]),
    productPrice: new FormControl('',
      [Validators.required]),
  })

  constructor(private _myProductsService: MyProductsService,
              private _fb: FormBuilder) { }

  ngOnInit(): void {
  }

  submitForSale(){
    const createProduct = this.newProductForm.value as CreateProduct;
    this._myProductsService.createProduct(createProduct).subscribe();
  }
}
