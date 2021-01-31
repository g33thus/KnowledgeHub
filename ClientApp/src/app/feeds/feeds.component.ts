import { Component, OnInit } from '@angular/core';

@Component({
  selector: "app-feeds",
  templateUrl: "./feeds.component.html",
  styleUrls: ["./feeds.component.scss"],
})
export class FeedsComponent implements OnInit {
  isFeedView: boolean = true;
  tagList: Array<any> = [];
  articleList: Array<any> = [];
  ngOnInit() {}

  setTagList(tagList) {
    this.tagList = tagList;
    console.log(tagList);
  }
  setArticleList(articleList) {
    this.articleList = articleList;
    console.log(this.articleList);
  }
}
