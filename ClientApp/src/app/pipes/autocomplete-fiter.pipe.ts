import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "autocompletefilter",
})
export class AutoCompleteFilterPipe implements PipeTransform {
  transform(list, searchKey, isAutocomplete) {
    if (searchKey && isAutocomplete) {
      return list.filter((listItem) =>
        listItem.toLowerCase().includes(searchKey.toLowerCase())
      );
    } else {
      return list;
    }
  }
}
