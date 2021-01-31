import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ArticlesService } from "src/app/services/articles.service";
import { PostTag } from '../models/PostTag';
import { AdminService } from '../services/admin.sevice';

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
  styleUrls: ["./admin.component.scss"],
})
export class AdminComponent implements OnInit {

  constructor(private articleService: ArticlesService,private adminService:AdminService,private spinner: NgxSpinnerService) {}

  postTag:PostTag;
  postTagList:Array<PostTag>=[];

  subscribeTag(tagId) {
    let userId = localStorage.getItem("userId");
    this.articleService.subscribeTag(Number(userId), tagId).subscribe((res) => {
      tagId.isSubscribed = true;
    });
  }

  subCategoryList:Array<any>=[];
  categoryList: Array<any> = [];
  categoryName: string;
  tagsList: Array<String> = [
    'Angular',
    "React",
    "Dotnet",
    "Azure",
    "HTML",
    "CSS",
    "Javascipt",
    "C#",
    "C",
    "CPP",
    "Angular",
    "React",
    "Dotnet",
    "Azure",
    "HTML",
    "CSS",
    "Javascipt",
    "C#",
    "C",
    "CPP",
    "Angular",
    "React",
    "Dotnet",
    "Azure",
    "HTML",
    "CSS",
    "Javascipt",
    "C#",
    "C",
    "CPP",
  ];

  ngOnInit(): void {
    this.articleService.getCategoryList().subscribe((res) => {
      this.categoryList = res;
    });
   
   
  }
  ngAfterViewInit()
  {

    this.postTag = new PostTag();
  }

  showSubCategory(category)
  {
    this.postTag.CategoryId=category.id;
    this.postTag.CategoryName= category.name;
    this.subCategoryList = category.subCategory;
  }
  showTag(subCategoryId)
  {
  this.articleService.getTagList(subCategoryId,1).subscribe((res)=>{
  this.tagsList=res;
  })
  }

  EditSubCategory(event)
  {
    
    this.postTag.SubCategoryId= event.id;
    this.postTag.SubCategoryName=event.name;
    this.postTagList=[];
    debugger;
    this.postTagList.push(this.postTag);   
  }

  addNewCategory(event) {
    this.postTagList=[];
    let category = {
      name: this.categoryName,
      isEdit: false,
    };
    
    this.categoryList.unshift(category);
    this.postTag.CategoryName=category.name;    
   
  }
  addNewSubCategory(event)
  {
    let subCategory={
      name:event,
      isEdit: false
    }
   this.subCategoryList.push(subCategory);
   this.postTag.SubCategoryName=subCategory.name;
   this.postTagList=[];
   this.postTagList.push(this.postTag);
  }

  deleteCategory(categoryName) {
    this.categoryList = this.categoryList.filter(
      (category) => category.name != categoryName
    );
  }
  saveChanges(){
  
    this.spinner.show();
    this.adminService.addOrUpdate(this.postTagList).subscribe((res)=>{
      console.log(res);
    });

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
   
  }
}

