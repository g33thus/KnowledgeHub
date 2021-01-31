import { NgModule } from "@angular/core";
import { AutocompleteComponent } from "./autocomplete/autocomplete.component";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AutoCompleteFilterPipe } from "../pipes/autocomplete-fiter.pipe";
import { DirectivesModule } from "../directives/directives.module";

@NgModule({
  declarations: [AutocompleteComponent, AutoCompleteFilterPipe],
  imports: [CommonModule, FormsModule, DirectivesModule],
  exports: [AutocompleteComponent],
})
export class SharedModule {}
