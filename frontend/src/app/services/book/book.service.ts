import {inject, Injectable} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {json} from "express";

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

  reserveBook(bookId:string){

    const user = localStorage.getItem('user');
    const token = user? JSON.parse(user).token : ''

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    // Create the request body and options
    const body = { id: bookId, status: 0 };
    const options = { headers: headers };

    return this.http.post(`${this.baseUrl}/userbook/reserveorreturn`, body, options);

  }

}
