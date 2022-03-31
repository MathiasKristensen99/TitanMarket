import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsRoutingModule } from './products-routing.module';
import {ProductsComponent} from "./list/products.component";
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    ProductsComponent,
  ],
    imports: [
        CommonModule,
        ProductsRoutingModule,
        HttpClientModule,
        FormsModule
    ]
})
export class ProductsModule { }
