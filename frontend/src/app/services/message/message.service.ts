import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private messageSubject = new BehaviorSubject<{ message: string, type: 'success' | 'error' } | null>(null);
  message$ = this.messageSubject.asObservable();

  setMessage(message: string, type: 'success' | 'error'): void {
    this.messageSubject.next({ message, type });
    setTimeout(() => this.messageSubject.next(null), 3000); // Hide message after 3 seconds
  }
}
