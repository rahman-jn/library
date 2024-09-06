import {inject, Injectable} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {json} from "express";
import {AuthService} from "../auth/auth.service";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private router: Router,private authService:AuthService) {}
  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);

  getBooks(checkReserveStatus = false): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/book`, {
      params: { "checkReserveStatus": checkReserveStatus.toString() }
    });
  }

  reserveBook(bookId:string){
    // Create the request body and options
    const body = { id: bookId, status: 0 };
    const options = this.authService.getOptions();

    return this.http.post(`${this.baseUrl}/userbook/reserveorreturn`, body, options);

  }

}
