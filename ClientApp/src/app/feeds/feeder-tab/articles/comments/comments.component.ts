import { Component, OnInit, Input } from "@angular/core";
import { ArticlesService } from "../../../../services/articles.service";
import { Comment } from "../../../../models/comment";
@Component({
  selector: "app-feeder-comments",
  templateUrl: "./comments.component.html",
  styleUrls: ["./comments.component.scss"],
})
export class CommentsComponent implements OnInit {
  isShowCommentDetails = false;
  @Input() article:any;
  comments: Array<any>;
  newComment: string = "";
  constructor(private articleService: ArticlesService) { }
  toggleDisplayCommentDetails() {
    this.isShowCommentDetails = !this.isShowCommentDetails;
  }
  ngOnInit() {
    this.getComments();
    console.log(this.article);
  }

  getComments() {
    this.articleService
      .getComments(this.article.id)
      .subscribe((result) => {
        this.comments = result;
        console.log(this.comments);
      });
  }
 

  addComment() {
    let newComment = {
      user: {
      name:"Adarsh Dilu Mathew"
      },
      description: this.newComment
    };
    this.comments.push(newComment);
    const comment: Comment = {
      userId: localStorage.getItem("userId"),
      articleId: this.article.id,
      description: this.newComment
    }
    this.articleService.commentArticle(comment).subscribe((result) => {
      if (result) {
        this.newComment = "";
        this.getComments();
      }
    });
  }

  likeArticle(article, islikedBool) {
    let body = {
      userId: localStorage.getItem("userId"),
      isLiked : islikedBool,
      isSaved : article.isSaved,
      isMarkedRead: article.isMarkedRead,
      articleId: article.articleId,
      id: article.id,
      tagId : article.tagId
    }
    this.articleService
      .updateArticle(body)
      .subscribe((result) => {
        console.log(result);
      
          article.isLiked = !article.isLiked;
       
      });
  }
  saveArticle(article, isSavedBool) {
    let body = {
      userId: localStorage.getItem("userId"),
      isLiked : article.isLiked,
      isSaved : isSavedBool,
      isMarkedRead: article.isMarkedRead,
      articleId: article.articleId,
      id: article.id,
      tagId : article.tagId
    }
    this.articleService
      .updateArticle(body)
      .subscribe((result) => {
        console.log(result);   
          article.isSaved = !article.isSaved;    
      });
  }
}
