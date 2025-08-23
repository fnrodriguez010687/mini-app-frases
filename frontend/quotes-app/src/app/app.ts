import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { QuoteList } from './components/quote-list/quote-list';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, QuoteList],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('quotes-app');
}
