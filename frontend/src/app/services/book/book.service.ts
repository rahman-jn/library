import {inject, Injectable} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private router: Router) {}
  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);

  getBooks(checkReserveStatus = false): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/book`, {
      params: { "checkReserveStatus": checkReserveStatus.toString() }
    });
  }

}
