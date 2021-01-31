import { Component, OnInit, Input } from "@angular/core";
import { ArticlesService } from "src/app/services/articles.service";
import { UserService } from "src/app/services/user.service";

@Component({
  selector: "app-subscribe-tab",
  templateUrl: "./subscribe-tab.component.html",
  styleUrls: ["./subscribe-tab.component.scss"],
})
export class SubscribeTabComponent implements OnInit {
  constructor(private articleService: ArticlesService,private userService:UserService) {}
  pageNumber: Number = 1;
  selectedCategory: string;
  selectedTag: string;
  tagStatus: string = "All Tags";
  showCategory: boolean = false;
  showTag: boolean = false;
  isAscending: boolean = true;
  itemsPerPage: number = 5;
  userId:any;
  userTags:any;
  categoryList: Array<String> = [];
  tagListToFilter: Array<any> = [];
  @Input()
  tagsList: Array<String> = [];
  subscriptionStatusList: Array<String> = [
    "All Tags",
    "Subscribed",
    "Unsubscribed",
  ];
  sortAlphabetically() {

    this.isAscending = !this.isAscending;
    this.tagsList.sort();
    if (this.isAscending === false) {
      this.tagsList.reverse();
    }
  }

  ngOnInit() {

    this.userService.getUserId().subscribe((res) => {
      this.userId=res;
   
      });
     
     
    }

  ngOnChanges() {
   
    this.tagListToFilter = this.tagsList.slice();
    this.articleService.getTagsSubscribed(this.userId).subscribe((userTags) => {
      this.userTags = userTags;
     
       
    });

   
  }
  autoComplete(searchString, list) {
    list = [];
  }

  subscribeTag(tag) {
  
    this.articleService.subscribeTag(this.userId,tag.id).subscribe((res) => {
      if (res) {
    
        tag.isUserSubscribed = true;
                

        }
    });
  }
  unSubscribeTag(tag) {
    this.articleService.unSubscribeTag(this.userTags.find(m=>m.tagId===tag.id  && m.tag.name===tag.name).id).subscribe((res) => {      
      tag.isUserSubscribed= false;
    
    });
  }

  filterTag(filterType) {
    this.tagStatus = filterType;
    switch (filterType) {
      case 'All Tags':
        this.tagsList = this.tagListToFilter;
        break;
      case 'Subscribed':
        this.tagsList = this.tagListToFilter.filter(tag => tag.isUserSubscribed);
        break;
      case 'Unsubscribed':
        this.tagsList = this.tagListToFilter.filter(
          (tag) => !tag.isUserSubscribed
        );
        break;
    }
  }

  onSearchFilterTags(searchValue: string) {
   
    this.tagsList = this.tagListToFilter.filter((listItem) => {
  
      return searchValue
        ? listItem.name.toLowerCase().includes(searchValue.toLowerCase())
        : true;
    });
  }
}
