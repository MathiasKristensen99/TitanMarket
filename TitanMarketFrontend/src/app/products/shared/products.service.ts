import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {ProductList} from "./product-list.model";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productsApi = environment.api + 'api/products'

  constructor(private _http: HttpClient) {
  }

  getProducts(): Observable<ProductList> {
    return this._http.get<ProductList>(this.productsApi);
  }
}
