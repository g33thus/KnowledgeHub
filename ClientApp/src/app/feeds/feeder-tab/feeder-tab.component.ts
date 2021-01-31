import { Component, OnInit, Input,OnChanges } from '@angular/core';

@Component({
  selector: "app-feeder-tab",
  templateUrl: "./feeder-tab.component.html",
  styleUrls: ["./feeder-tab.component.scss"],
})
export class FeederTabComponent implements OnInit {
  isSubscribed: boolean = true;
  @Input()
  articleList: Array<any> = [];

  ngOnInit() {}
  ngOnChanges() {
    console.log(this.articleList);
  }
}
