import { BrowserModule } from "@angular/platform-browser";
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { NavModule } from "./nav/nav.module";

import { AppRoutingModule } from "./app.routing.module";
import { MsalApplicationModule } from "./core/msal-application.module";
import { InfiniteScrollModule } from "ngx-infinite-scroll"; 
import { NgxSpinnerModule } from "ngx-spinner";

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from "@angular/material/dialog";
import { WelcomeModalComponent } from "./shared/components/welcome-modal/welcome-modal";

@NgModule({
  declarations: [AppComponent, WelcomeModalComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    AppRoutingModule,
    NavModule,
    MsalApplicationModule.forRoot("config/config.json"),
    InfiniteScrollModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    MatDialogModule
  ],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
  entryComponents: [WelcomeModalComponent]
})
export class AppModule {}
