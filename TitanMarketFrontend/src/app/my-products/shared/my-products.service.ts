import {CreateProduct} from "./create-product.model";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class MyProductsService {
  private productsApi = environment.api + 'api/products'

  constructor(private _http: HttpClient) {
  }

  createProduct(createProduct: CreateProduct): Observable<CreateProduct> {
    return this._http
      .post<CreateProduct>(this.productsApi, createProduct);
  }
}
