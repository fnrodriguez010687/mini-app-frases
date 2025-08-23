import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideHttpClient } from '@angular/common/http';
import { QuoteList } from './components/quote-list/quote-list';
import { RouterModule, Routes } from '@angular/router';
import { QuoteDetail } from './components/quote-detail/quote-detail';

const routes: Routes = [
  { path: '', component: QuoteList },
    { path: 'quotes/:id', component: QuoteDetail }
  // otras rutas...
];


@NgModule({
  declarations: [],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)

  ],
  providers: [provideHttpClient()]
})
export class AppModule { }
