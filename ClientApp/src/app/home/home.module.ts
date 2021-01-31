import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home.routing.module';

@NgModule({
  declarations: [
    HomeComponent  
    ],
  imports: [
    FormsModule,
    CommonModule,
    HomeRoutingModule
  ],
  providers: [],
  exports: [
      HomeComponent
    ]
})
export class HomeModule { }