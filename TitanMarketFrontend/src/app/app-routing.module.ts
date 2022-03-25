import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NewItemComponent} from "./my-products/new-item/new-item.component";

const routes: Routes = [
  {
    path: 'products',
    loadChildren: () => import('./products/products.module')
      .then(m => m.ProductsModule)
  },
  {
    path: 'my-products',
    loadChildren: () => import('./my-products/my-products.module')
      .then(m => m.MyProductsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
