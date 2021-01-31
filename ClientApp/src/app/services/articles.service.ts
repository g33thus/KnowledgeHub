import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ConfigService } from "../../../src/app/core/services/config.services";
import { Articles } from "../models/Articles";
import { Observable } from "rxjs";
@Injectable({
  providedIn: "root",
})
export class ArticlesService {
  tagId: any;
  constructor(private httpClient: HttpClient, private config: ConfigService) {}
  apiBaseURL = this.config.getSettings("apiBaseURL");

  setTagIdForScrolltagId(tagId) {
    this.tagId = tagId;
  }

  getTagIdForScrolltagId() {
    return this.tagId;
  }

  public getArticles(userId, userTagId, pageNumber): Observable<any> {
    let body = {
      userId,
      userTagId,
      pageNumber,
    };
    return this.httpClient.post<Observable<any>>(
      this.apiBaseURL + `articles/db`,
      body
    );
  }

  public getArticlesFromService(userId, tagList): Observable<any> {
    let body = {
      userId,
      tagList,
    };
    console.log(body);
    return this.httpClient.post<Observable<any>>(
      this.apiBaseURL + `articles`,
      body
    );
  }

  getCategoryList(): Observable<any> {
    return this.httpClient.get(this.apiBaseURL + "Category");
  }

  public getTagList(subCategoryId: number, userId: number): Observable<any> {
    const result = this.httpClient.get(
      this.apiBaseURL + `tag?subCategoryId=${subCategoryId}&&userId=${userId}`
    );
    return result;
  }

  public subscribeTag(userId, tagId): Observable<any> {
    let body = { tagId, userId };
    const result = this.httpClient.post(
      this.apiBaseURL + "tag/subscribe",
      body
    );
    return result;
  }
  public unSubscribeTag(userTagId): Observable<any> {
    const result = this.httpClient.delete(
      this.apiBaseURL + `tag/unsubscribe?userTagId=${userTagId}`
    );
    return result;
  }

  getTagsSubscribed(userId): Observable<any> {
    const result = this.httpClient.get(
      this.apiBaseURL + "category/withUserId?userId=" + userId
    );
    return result;
  }

  updateArticle(body): Observable<any> {
    const result = this.httpClient.put(
      this.apiBaseURL + "UserArticle/UpdateUserArticle",
      body
    );
    return result;
  }

  commentArticle(body): Observable<any> {
    const result = this.httpClient.post(
      this.apiBaseURL + "UserArticle/Comment",
      body
    );
    return result;
  }

  getComments(articleId): Observable<any> {
    const result = this.httpClient.get(
      this.apiBaseURL + "UserArticle/Comments?articleId=" + articleId
    );
    return result;
  }

  replyToCommeents(body): Observable<any> {
    const result = this.httpClient.post(
      this.apiBaseURL + "/api/UserArticle/Reply",
      body
    );
    return result;
  }
}
