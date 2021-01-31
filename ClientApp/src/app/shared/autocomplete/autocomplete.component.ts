import { Component, OnInit,Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: "app-autocomplete",
  templateUrl: "./autocomplete.component.html",
  styleUrls: ["./autocomplete.component.scss"],
})
export class AutocompleteComponent implements OnInit {
  constructor() {}
  @Input()
  list: Array<string>;
  @Input()
  placeholder: string;
  showDropdown: boolean = false;
  @Input()
  isAutocomplete: boolean = true;
  @Output()
  userInput: EventEmitter<string> = new EventEmitter<string>();
  userEntry: string = "";
  ngOnInit() {
  }

  searchSidebarFilter(event) {
    this.userEntry = event;
    this.userInput.emit(this.userEntry);
  }
}
