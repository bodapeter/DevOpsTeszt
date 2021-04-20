import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { API_BASE_URL } from './app/services/greetings-service.service';
import { environment } from './environments/environment';


fetch('assets/config.json').then(async res => {
  const config = await res.json();

  const providers = [
    { provide: API_BASE_URL, useValue: config.apiBaseUrl }
  ];

  if (environment.production) {
    enableProdMode();
  }

  platformBrowserDynamic(providers).bootstrapModule(AppModule)
    .catch(err => console.error(err));

});
