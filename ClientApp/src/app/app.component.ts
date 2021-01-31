import { Component } from "@angular/core";
import { MsalService, BroadcastService } from "@azure/msal-angular";
import { NgxSpinnerService } from "ngx-spinner";
import { UserService } from "./services/user.service";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { WelcomeModalComponent } from "./shared/components/welcome-modal/welcome-modal";
import { User } from "./models/User";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  title = "app";
  loggedIn = false;
  userAccount: any;
  user: User = new User();
  userId: number = null;

  constructor(
    private msalService: MsalService,
    private userService: UserService,
    private readonly broadcastService: BroadcastService,
    private spinner: NgxSpinnerService,
    public matDialog: MatDialog
  ) {}

  async ngOnInit() {
    this.checkAccount();

    this.broadcastService.subscribe("msal:loginSuccess", () => {
      this.checkAccount();
    });

    this.msalService.handleRedirectCallback((authError, response) => {
      if (response && !authError) {
        this.user.name = response.account.name;
        this.user.email = response.account.userName;
        this.userService.addUser(this.user).subscribe((result) => {
          this.userId = result;
          console.log(this.userAccount);
          localStorage.setItem('userId', this.userId.toString());
        });
        localStorage.setItem("lastUser", response.account.userName);
      }
    });

    const loginHint = localStorage.getItem("lastUser");
    const resp = await this.msalService.acquireTokenSilent({
      scopes: ["openid", "profile"],
      loginHint,
    });

    this.broadcastService.broadcast("msal:loginSuccess", resp);
  }

  checkAccount() {
    if (this.userId) {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.id = "modal-component";
      dialogConfig.height = "350px";
      dialogConfig.width = "600px";
      this.matDialog.open(WelcomeModalComponent, dialogConfig);
      this.userId = null;
    }
    this.userAccount = this.msalService.getAccount();
    this.loggedIn = !!this.userAccount;
  }
}
