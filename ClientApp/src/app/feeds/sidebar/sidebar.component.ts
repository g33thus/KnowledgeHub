import { Component, Input, OnInit, SimpleChanges, Output,EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { ArticlesService } from 'src/app/services/articles.service';
import { UserService } from 'src/app/services/user.service';
import { forkJoin } from "rxjs";
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: "sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.scss"],
})
export class SidebarComponent implements OnInit {
  showSubCategoryHeading: boolean = false;
  showTagsHeading: boolean = false;
  showTagsList: boolean = false;
  sidebarList: Array<String> = [];
  searchFilter: string = "";
  sidebarListToFilter: Array<any> = [];
  @Input() isFeedView: boolean;
  tagSubscribedList: Array<any> = [];
  categoryListForSubscription: Array<any> = [];
  categoryListForArticle: Array<any> = [];
  subCategoryListForArticle: Array<any> = [];
  tagListforArticle: Array<any> = [];
  tagList: Array<any> = [];
  articleList: Array<any> = [];
  @Output()
  tagListEmmiter = new EventEmitter<Array<any>>();
  @Output()
  articleListEmmiter = new EventEmitter<Array<any>>();
  @ViewChild("backButton", {
    static: false,
  })
  backButton: ElementRef;
  pageNumber: number = 5;
  userId: any;

  constructor(
    private articleService: ArticlesService,
    private userService: UserService,
    private spinner: NgxSpinnerService
  ) {}

  ngOnInit() {
    this.spinner.show();
    let mapList = [];
    this.userService.getUserId().subscribe((res) => {
      this.userId = res;
      this.articleService.getTagsSubscribed(this.userId).subscribe((userTags) => {
        this.tagSubscribedList = userTags;
        console.log(this.tagSubscribedList, "id");
        if (userTags.length) {
          mapList = userTags.map(
            (tagObject) => tagObject.tag.subCategory.category
          );

          mapList.forEach((element) => {
            if (
              !this.categoryListForArticle.some(
                (obj) => obj.name === element.name
              )
            ) {
              this.categoryListForArticle.push(element);
            }
          });
        }

        this.sidebarList = this.categoryListForArticle;
      }, (error) => {
        console.log(error);
      }, () => {
        let targetList = this.tagSubscribedList.map((tagObj) => {
          return { name: tagObj.tag.name, id: tagObj.tag.id };
        });

          this.articleService.getArticles(4
            , null, this.pageNumber).subscribe(data => {
          console.log(data);
          this.spinner.hide();
              this.articleListEmmiter.emit(data);
        });
        // forkJoin(
        //   this.articleService.getArticlesFromService(this.userId, targetList),
        //   this.articleService.getArticles(
        //     this.userId,
        //     null,
        //     this.pageNumber
        //   )
        // ).subscribe(articles => {
        //   console.log(articles)
        // });
      });
   
        
       
    });

    this.articleService.getCategoryList().subscribe((res) => {
      res.forEach((element) => {
        if (
          !this.categoryListForSubscription.some(
            (obj) => obj.name === element.name
          )
        ) {
          this.categoryListForSubscription.push(element);
        }
      });
    });
    
  }
  ngOnChanges(changes: SimpleChanges) {
    this.sidebarList = this.isFeedView
      ? this.categoryListForArticle
      : this.categoryListForSubscription;
    if (changes.isFeedView.currentValue !== changes.isFeedView.previousValue) {
      this.showTagsHeading = false;
      this.showSubCategoryHeading = false;
    }
  }
  showSubCategory(categoryId,categoryName) {
    if (this.isFeedView) {
      let subCatList =
        this.tagSubscribedList.length &&
        this.tagSubscribedList.filter((i) => {
          return i.tag.subCategory.category.id === categoryId;
        });
      if (subCatList.length) {
        let mapList = subCatList.map((obj) => obj.tag.subCategory);
        mapList.forEach((element) => {
          if (
            !this.subCategoryListForArticle.some(
              (obj) => obj.name === element.name
            )
          ) {
            this.subCategoryListForArticle.push(element);
          }
        });
        this.sidebarList = this.subCategoryListForArticle;
        console.log(this.sidebarList);
        this.showSubCategoryHeading = true;
      } else {
        this.showSubCategoryHeading = false;
        this.showTagsHeading = true;
        let tagObjList = this.tagSubscribedList.filter((i) => {
          return i.tag.subCategory.id === categoryId;
        });
        console.log(tagObjList);
        if (tagObjList.length) {
          let mapList = tagObjList.map((obj) => obj.tag);
          console.log(mapList);
          mapList.forEach((element) => {
            if (
              !this.tagListforArticle.some((obj) => obj.name === element.name)
            ) {
              this.tagListforArticle.push(element);
            }
          });
          this.sidebarList = this.tagListforArticle;
          this.showTagsHeading = true;
        } else {
          console.log("hi")
          
          this.articleService
            .getArticles(this.userId, categoryId, this.pageNumber)
            .subscribe((articleList) => {
              console.log(articleList);
              this.articleListEmmiter.emit(articleList);
              this.articleService.setTagIdForScrolltagId(categoryId);

            });
          
        }
      }
      setTimeout(() => {
        let focusElem = this.backButton.nativeElement;
        focusElem.focus();
      });
    } else {
      if (!this.showSubCategoryHeading) {
        this.showSubCategoryHeading = true;
        let categoryObj = this.categoryListForSubscription.find((i) => {
          return i.id === categoryId;
        });
        this.sidebarList = categoryObj && categoryObj.subCategory;
      } else {
        this.articleService
          .getTagList(categoryId, this.userId)
          .subscribe((res) => {
            this.tagList = res;
            console.log(this.tagList);
            //(this.tagList[0].id);
            this.tagListEmmiter.emit(this.tagList);
          });
      }
      this.showSubCategoryHeading = true;
    }

    this.sidebarListToFilter = this.sidebarList;
  }
  onSearchFilter(searchValue: string) {
    this.sidebarList = this.sidebarListToFilter.filter((listItem) =>
      searchValue
        ? listItem.name.toLowerCase().includes(searchValue.toLowerCase())
        : true
    );
  }

  goToCategory() {
    this.showSubCategoryHeading = !this.showSubCategoryHeading;
    this.sidebarList = this.isFeedView
      ? this.categoryListForArticle
      : this.categoryListForSubscription;
  }
  goToSubcategory() {
    this.showTagsHeading = false;
    this.showSubCategoryHeading = true;
    this.sidebarList = this.subCategoryListForArticle;
  }
}
