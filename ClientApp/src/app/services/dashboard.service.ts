import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ConfigService } from "../../../src/app/core/services/config.services";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class DashboardService {
  constructor(private httpClient: HttpClient, private config: ConfigService) { }

  public getDashboardDetails(userId): Observable<any> {
    const apiBaseURL = this.config.getSettings("apiBaseURL");
    return this.httpClient.get<any>(apiBaseURL + "UserArticle/Dashboard/" + userId);
  }
}
