import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartAndOrdersComponent } from './cart-and-orders.component';

const routes: Routes = [
  { path: '', component: CartAndOrdersComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CartAndOrdersRoutingModule { }
