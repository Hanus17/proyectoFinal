import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EpharmaTypeClassPipe } from './epharma-type-class.pipe';



@NgModule({
  declarations: [
    EpharmaTypeClassPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [EpharmaTypeClassPipe]
})
export class EPharmaTypeClassModule { }
