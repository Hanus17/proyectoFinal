import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'products',
        loadChildren: () => import('./modules/products/products.module').then(m => m.ProductsModule)
      },
      {
        path: 'store',
        loadChildren: () => import('./modules/store/store.module').then(m => m.StoreModule)
      },
      {
        path: 'orders',
        loadChildren: () => import('./modules/cart-and-orders/cart-and-orders.module').then(m => m.CartAndOrdersModule)
      },
      {
        path: 'about',
        loadChildren: () => import('./modules/acerca-de/acerca-de/acerca-de.module').then(m => m.AcercaDeModule)
      }
    ]
  },
  {
    path: '**', 
    redirectTo: 'store' // Ruta comodín para manejar 404
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
