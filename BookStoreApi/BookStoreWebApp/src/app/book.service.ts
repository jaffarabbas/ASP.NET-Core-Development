import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseUrl = 'https://localhost:44352/api/book';
  constructor(private http: HttpClient) { }

  public getBooks(): Observable<any>{
    return this.http.get(this.baseUrl);
  }

  public addBooks(book: any): Observable<any>{
    return this.http.post(this.baseUrl, book);
  }
}
