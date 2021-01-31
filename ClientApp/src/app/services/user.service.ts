import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ConfigService } from "../../../src/app/core/services/config.services";
import { User } from "../models/User";
import { Observable } from "rxjs";
import { MsalService } from "@azure/msal-angular";
import { ReturnStatement } from "@angular/compiler";


@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(
    private httpClient: HttpClient,
    private config: ConfigService,
    private msalService: MsalService
  ) {}

  public addUser(user): Observable<number> {
    const apiBaseURL = this.config.getSettings("apiBaseURL");
    return this.httpClient.post<number>(apiBaseURL + "users", user);
  }

  public getUserId() {
    let userAccount = this.msalService.getAccount();
    console.log(userAccount)
    return this.addUser({ email: userAccount.userName }) 
  }
}
