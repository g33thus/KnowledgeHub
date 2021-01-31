import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ConfigService } from "../../../src/app/core/services/config.services";
import { PostTag } from "../models/PostTag";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AdminService {
  constructor(private httpClient: HttpClient, private config: ConfigService) { }

  public addOrUpdate(postTag: PostTag[]): Observable<boolean> {
    const apiBaseURL = this.config.getSettings("apiBaseURL");    
    return this.httpClient.post<boolean>(apiBaseURL+ "category", postTag);
  }
}