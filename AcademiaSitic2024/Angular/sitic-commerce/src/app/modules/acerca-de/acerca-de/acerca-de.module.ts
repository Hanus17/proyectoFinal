// acerca-de.module.ts
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { AcercaDeComponent } from './acerca-de.component'; 
import { AcercaDeRoutingModule } from './acerca-de-routing.module'; 

@NgModule({
  declarations: [AcercaDeComponent], 
  imports: [
    CommonModule,                    
    AcercaDeRoutingModule             
  ]
})
export class AcercaDeModule { }


