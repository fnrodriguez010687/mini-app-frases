import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/enviroment';
import { Quote } from '../models/quote.models';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private baseUrl = `${environment.apiUrl}/quotes`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Quote[]> {
    return this.http.get<Quote[]>(this.baseUrl);
  }

  getById(id: number): Observable<Quote> {
    return this.http.get<Quote>(`${this.baseUrl}/${id}`);
  }

}
