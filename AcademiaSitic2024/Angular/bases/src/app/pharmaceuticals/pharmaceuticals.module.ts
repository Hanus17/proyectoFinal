import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PharmaceuticalsComponent } from './pages/pharmaceuticals/pharmaceuticals.component';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'
import { MatFormFieldModule } from '@angular/material/form-field';
import { ListComponent } from './components/list/list.component';
import { AddPharmaceuticalsComponent } from './components/add-pharmaceuticals/add-pharmaceuticals.component';
import { EPharmaTypeClassModule } from '../shared/pipes/epharma-type-class/epharma-type-class.module';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    PharmaceuticalsComponent,
    ListComponent,
    AddPharmaceuticalsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    EPharmaTypeClassModule
  ],
  exports: [PharmaceuticalsComponent]
})
export class PharmaceuticalsModule { }
