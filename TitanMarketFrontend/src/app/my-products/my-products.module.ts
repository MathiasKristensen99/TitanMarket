import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyProductsRoutingModule } from './my-products-routing.module';
import {MyProductsComponent} from "./main-page/my-products.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { NewItemComponent } from './new-item/new-item.component';


@NgModule({
  declarations: [
    MyProductsComponent,
    NewItemComponent,
  ],
  imports: [
    CommonModule,
    MyProductsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MyProductsModule { }
