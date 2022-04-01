import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NewItemComponent} from "./my-products/new-item/new-item.component";

const routes: Routes = [
  {path: 'auth', loadChildren: () =>
      import('./auth/auth.module')
        .then(f => f.AuthModule)},

  {
    path: 'products',
    loadChildren: () => import('./products/products.module')
      .then(m => m.ProductsModule)
  },
  {
    path: 'my-products',
    loadChildren: () => import('./my-products/my-products.module')
      .then(m => m.MyProductsModule)
  },
  {
    path: 'checkout',
    loadChildren: () => import('./checkout/checkout.module')
      .then(m => m.CheckoutModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
