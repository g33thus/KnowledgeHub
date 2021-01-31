import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NavComponent } from './nav.component';
import { RouterModule } from "@angular/router";
import { CommonModule } from '@angular/common';
import { DirectivesModule } from '../directives/directives.module';

@NgModule({
  declarations: [NavComponent],
  imports: [FormsModule, RouterModule, CommonModule, DirectivesModule],
  providers: [],
  exports: [NavComponent],
})
export class NavModule {}
