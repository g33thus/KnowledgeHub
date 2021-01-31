import { Component, OnInit, Input } from "@angular/core";
import { ArticlesService } from "../../../services/articles.service";
import { DomSanitizer, SafeResourceUrl, SafeUrl} from '@angular/platform-browser';
import { Articles } from "src/app/models/Articles";
@Component({
  selector: "app-feeder-articles",
  templateUrl: "./articles.component.html",
  styleUrls: ["./articles.component.scss"],
})
export class ArticlesComponent implements OnInit {
  articles: Articles[];
  noOfArticlesToShowInitially: number = 5;
  articlesToLoad: number = 5;
  articlesToShow: Articles[];
  isFullListDisplayed: boolean = false;
  articlesFilterBy: string = "All Articles";
  trustedDashboardUrl : SafeResourceUrl;
  iframeSrc: SafeUrl;
  userId: any;
  tagId: any;
  pageNumber: any=2;

  @Input()
  articleList: any[] = [];

  scrollThrottle: number = 50;
  scrollDistance: number = 2;

  constructor(private articleService: ArticlesService,
    private sanitizer: DomSanitizer
    ) {}
 
  ngOnInit() {
    this.userId = localStorage.getItem("userId");
    this.tagId = this.articleService.getTagIdForScrolltagId();
    console.log(this.articleList);
  }

  onScroll() {
    let tagId = this.tagId ? this.tagId : null;
    this.articleService
      .getArticles(this.userId, tagId, this.pageNumber)
      .subscribe((articleList) => {
        console.log(articleList);
        if(articleList.length)
        this.articleList = [...this.articleList,...articleList];
        this.pageNumber++;
      });
    // if (this.noOfArticlesToShowInitially <= this.articles.length) {
    //   this.noOfArticlesToShowInitially += this.articlesToLoad;
    //   this.articlesToShow = this.articles.slice(
    //     0,
    //     this.noOfArticlesToShowInitially
    //   );
    // } else {
    //   this.isFullListDisplayed = true;
    // }
  }
  transform() {
   
    this.iframeSrc = this.sanitizer.bypassSecurityTrustResourceUrl('https://dzone.com/articles/protecting-your-reactjs-source-code-with-jscramble');
    return this.iframeSrc;
    // this.trustedDashboardUrl = this.sanitizer.bypassSecurityTrustUrl("https://flatlogic.com/blog/react-js-vs-react-native-what-are-the-key-differences-and-advantages/");
    // return this.trustedDashboardUrl;
  }
  articlesFilter: Array<String> = [
    "All Articles",
    "Read Articles",
    "Saved Articles",
  ];
}
