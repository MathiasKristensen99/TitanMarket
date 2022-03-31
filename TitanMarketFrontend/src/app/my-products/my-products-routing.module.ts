import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MyProductsComponent} from "./main-page/my-products.component";
import {NewItemComponent} from "./new-item/new-item.component";

const routes: Routes = [
  {path: '', component: MyProductsComponent},
  {path: 'new-item', component: NewItemComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyProductsRoutingModule { }
