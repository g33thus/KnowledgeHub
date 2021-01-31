import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from '../admin/admin.component';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin.routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AdminComponent],
  imports: [
    RouterModule,
    CommonModule,
    AdminRoutingModule,
    FormsModule
  ],
  exports: [
    AdminComponent
    ]
})
export class AdminModule { }
