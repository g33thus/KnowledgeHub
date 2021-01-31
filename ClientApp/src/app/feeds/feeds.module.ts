import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { FeedsComponent } from "./feeds.component";
import { CommonModule } from "@angular/common";
import { FeedsRoutingModule } from "./feeds.routing.module";
import { FeederTabComponent } from "./feeder-tab/feeder-tab.component";
import { ArticlesComponent } from "./feeder-tab/articles/articles.component";
import { CommentsComponent } from "./feeder-tab/articles/comments/comments.component";
import { SubscribeTabComponent } from "./subscribe-tab/subscribe-tab.component";
import { SidebarComponent } from "../feeds/sidebar/sidebar.component";
import { SharedModule } from "../shared/shared.module";
import { InfiniteScrollModule } from "ngx-infinite-scroll";
import { NgxPaginationModule } from "ngx-pagination";

@NgModule({
  declarations: [
    FeedsComponent,
    FeederTabComponent,
    ArticlesComponent,
    CommentsComponent,
    SubscribeTabComponent,
    SidebarComponent,
  ],
  imports: [
    FormsModule,
    CommonModule,
    FeedsRoutingModule,
    SharedModule,
    InfiniteScrollModule,
    NgxPaginationModule,
  ],
  providers: [],
  exports: [FeedsComponent],
})
export class FeedsModule {}
