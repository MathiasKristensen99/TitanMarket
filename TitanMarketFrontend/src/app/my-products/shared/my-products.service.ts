import {CreateProduct} from "./create-product.model";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {ProductList} from "../../products/shared/product-list.model";
import {Product} from "../../products/shared/product.model";
import {AuthService} from "../../auth/shared/auth.service";

@Injectable({
  providedIn: 'root'
})
export class MyProductsService {
  private productsApi = environment.api + 'api/products'

  constructor(private _http: HttpClient, private _authService: AuthService) {
  }

  createProduct(createProduct: CreateProduct): Observable<CreateProduct> {
    return this._http
      .post<CreateProduct>(this.productsApi, createProduct);
  }

  getMyProducts(): Observable<ProductList>{
    //if (localStorage.length<0) {
    //  return null;
    //}
    //let loggedInUser = this._authService.getLoggedInDto();
    return this._http.get<ProductList>(this.productsApi);
  }

  update(itemToUpdate: number, updatedItem: Product): Observable<Product> {
    return this._http.patch<Product>(this.productsApi + '/' + itemToUpdate, updatedItem);
  }

  getProductById(product: number): Observable<Product> {
    return this._http.get<Product>(this.productsApi + '/'+ product)
  }

  deleteProduct(id: number): Observable<Product> {
    return this._http.delete<Product>(this.productsApi + '/' + id);
  }
}
