import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard.component';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard.routing.module';
import { ChartsModule, ThemeService } from 'ng2-charts';

@NgModule({
  declarations: [
    DashboardComponent  
    ],
  imports: [
    FormsModule,
    CommonModule,
    DashboardRoutingModule,
    ChartsModule
  ],
  providers: [ThemeService],
  exports: [
    DashboardComponent
    ]
})
export class DashboardModule { }