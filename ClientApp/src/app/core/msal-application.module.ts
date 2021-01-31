import { InjectionToken, NgModule, APP_INITIALIZER } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Configuration } from 'msal';
import { MSAL_CONFIG, MSAL_CONFIG_ANGULAR, MsalAngularConfiguration, MsalService, MsalModule, MsalInterceptor } from '@azure/msal-angular';

import { ConfigService } from 'src/app/core/services/config.services';

const AUTH_CONFIG_URL_TOKEN = new InjectionToken<string>('AUTH_CONFIG_URL');

export function initializerFactory(env: ConfigService, configUrl: string) {
  // APP_INITIALIZER, except a function return which will return a promise
  // APP_INITIALIZER, angular doesnt starts application untill it completes
  return () => env.init(configUrl);
}

export function msalConfigFactory(config: ConfigService): Configuration {
  return {
    auth: {
      clientId: config.getSettings('clientId'),
      authority: config.getSettings('authority'),
      redirectUri: config.getSettings('redirectUri'),
      postLogoutRedirectUri: config.getSettings('redirectUri')
    },
    cache: {
      cacheLocation: config.getSettings('cacheLocation')
    }
  };
}

export function msalAngularConfigFactory(config: ConfigService): MsalAngularConfiguration {
  const auth = {
    consentScopes: [
      'user.read',
      'openid',
      'profile',
    ],
    unprotectedResources: config.getSettings('unprotectedResources'),
    protectedResourceMap: config.getSettings('protectedResourceMap'),
  };
  return (auth as MsalAngularConfiguration);
}

@NgModule({
  providers: [
  ],
  imports: [MsalModule]
})
export class MsalApplicationModule {

  static forRoot(configFile: string) {
    return {
      ngModule: MsalApplicationModule,
      providers: [
        ConfigService,
        { provide: AUTH_CONFIG_URL_TOKEN, useValue: configFile },
        {
          provide: APP_INITIALIZER, useFactory: initializerFactory,
          deps: [ConfigService, AUTH_CONFIG_URL_TOKEN], multi: true
        },
        {
          provide: MSAL_CONFIG,
          useFactory: msalConfigFactory,
          deps: [ConfigService]
        },
        {
          provide: MSAL_CONFIG_ANGULAR,
          useFactory: msalAngularConfigFactory,
          deps: [ConfigService]
        },
        MsalService,
        {
          provide: HTTP_INTERCEPTORS,
          useClass: MsalInterceptor,
          multi: true
        }
      ]
    };
  }
}
