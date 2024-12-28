import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartAndOrdersComponent } from './cart-and-orders.component';
import { CartAndOrdersRoutingModule }  from './cart-and-orders-routing.module';

@NgModule({
  declarations: [ CartAndOrdersComponent ],
  imports: [
    CommonModule,
    CartAndOrdersRoutingModule
  ]
})
export class CartAndOrdersModule { }

