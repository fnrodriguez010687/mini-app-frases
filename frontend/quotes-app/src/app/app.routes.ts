import { Routes } from '@angular/router';
import { QuoteList } from './components/quote-list/quote-list';
import { QuoteDetail } from './components/quote-detail/quote-detail';

export const routes: Routes = [
  { path: '', component: QuoteList },
  { path: 'quotes/:id', component: QuoteDetail }
];
