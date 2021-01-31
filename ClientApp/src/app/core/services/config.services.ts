import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

type Config = typeof import('src/config/config.json');
export type AppSettings = typeof import('src/config/environment.local.json');

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  public settings: AppSettings;
  public readonly initialized = new BehaviorSubject<any>(null);

  private http: HttpClient;

  constructor(private readonly httpHandler: HttpBackend) {
    this.http = new HttpClient(this.httpHandler);
  }

  init(endpoint: string): Promise<any> {
    return new Promise<any>((resolve, reject) => {

      this.http.get('config/config.json').subscribe((envdata: Config) => {
        const jsonPath = ('config/environment.' + envdata.EnvironmentSetting + '.json').toLowerCase();

        this.http.get(jsonPath)
          .subscribe(
            (value: AppSettings) => {
              this.settings = value;
              this.initialized.next(value);
              this.initialized.complete();

              resolve(value);
            },
            (error) => {
              reject(error);
            });
      });

    });
  }

  getSettings(key?: string | Array<string>): any {
    if (!key || (Array.isArray(key) && !key[0])) {
      return this.settings;
    }

    if (!Array.isArray(key)) {
      key = key.split('.');
    }

    return key.reduce((acc: any, current: string) => acc && acc[current], this.settings);
  }
}
