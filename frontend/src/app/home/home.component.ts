import {Component, inject} from '@angular/core';
import {AuthService} from "../services/auth/auth.service";
import {Router} from "@angular/router";
import {NgForOf} from "@angular/common";
import {BookService} from "../services/book/book.service";
import {async, Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  books: any[] = [];
  reservedBook: object = {};

  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);
constructor(private authService:AuthService, private router:Router, private bookService:BookService) {
  if(!authService.islogin())
    this.router.navigate(['/login'])
}
  ngOnInit(): void {
    this.getAvailableBooks();
  }

  getAvailableBooks(): void {
    this.bookService.getBooks(true).subscribe(
      (response: any[]) => {
        this.books = response;
      },
      error => {
        console.error('Failed to get books:', error);
      }
    );
  }

  reserveBook(bookId:string){
    this.bookService.reserveBook(bookId).subscribe(
      (response) => {
        this.reservedBook = response;
      },
      error => {
        console.error('Failed to get books:', error);
      }
    );
  }

}
