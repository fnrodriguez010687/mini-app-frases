import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Quote } from '../../models/quote.models';
import { QuoteService } from '../../services/quote';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-quote-list',
  imports: [RouterModule, CommonModule],
  templateUrl: './quote-list.html',
  styleUrl: './quote-list.scss'
})
export class QuoteList implements OnInit {
  quotes: Quote[] = [];

  constructor(private quoteService: QuoteService) {}

  ngOnInit(): void {
    this.quoteService.getAll()
      .subscribe(data => this.quotes = data);
  }


}
