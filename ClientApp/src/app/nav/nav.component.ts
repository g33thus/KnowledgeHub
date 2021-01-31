import { Component, Input } from '@angular/core';
import { MsalService, BroadcastService} from '@azure/msal-angular';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ConfigService } from '../core/services/config.services';

@Component({
  selector: 'nav-home',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {
  showCard: boolean = false;
  photo: any;
  profile: any;
  profilePhotoGraphApiUrl: string;
  profileDetailsGraphApiUrl: string;
  @Input() loggedIn: boolean;
  @Input() account: Account;

  constructor(private msalService: MsalService,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    private env: ConfigService
  ) { }
  ngOnInit() {
    this.profilePhotoGraphApiUrl = this.env.getSettings('profilePhotoGraphApiUrl');
    this.profileDetailsGraphApiUrl = this.env.getSettings('profileDetailsGraphApiUrl');
    if (this.loggedIn) {
      this.getUserPhoto().subscribe(photo =>
        this.photo = photo)


      this.http.get(this.profileDetailsGraphApiUrl).toPromise()
        .then(profile => {
          this.profile = profile;
        });
    }
  }

  getUserPhoto(): Observable<SafeUrl> {
    return this.http.get(this.profilePhotoGraphApiUrl, { responseType: "blob" }).pipe(map(result => {
      let url = window.URL;
      return this.sanitizer.bypassSecurityTrustUrl(url.createObjectURL(result));
    }));

  }

    onLogin() {
        this.msalService.loginRedirect();
    }

  onLogout() {
    this.msalService.logout();
  }
}
