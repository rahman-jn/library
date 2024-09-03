import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth/auth.service';
import { Router } from '@angular/router';
import { NgForOf } from '@angular/common';
import { BookService } from '../services/book/book.service';
import { HttpClient } from '@angular/common/http';
import { MessageService } from '../services/message/message.service';
import {MessageComponent} from "../message/message.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgForOf, MessageComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  books: any[] = [];
  reservedBook: object = {};

  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);
  messageService = inject(MessageService);

  constructor(private authService: AuthService, private router: Router, private bookService: BookService) {
    if (!authService.islogin()) {
      this.router.navigate(['/login']);
    }
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

  reserveBook(bookId: string): void {
    this.bookService.reserveBook(bookId).subscribe(
      (response) => {
        this.reservedBook = response;
        this.messageService.setMessage('Book reserved successfully!', 'success');
        this.getAvailableBooks(); // Refresh the list of available books
      },
      error => {
        console.error('Failed to reserve book:', error);
        this.messageService.setMessage('Failed to reserve the book.', 'error');
      }
    );
  }
}
