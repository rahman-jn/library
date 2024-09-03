import {inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Router} from "@angular/router";


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) {}
  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);

  login(user: any): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this.http.post(`${this.baseUrl}/auth`, user).subscribe(
        response => {
          localStorage.setItem('user', JSON.stringify(response));
          resolve(true);
        },
        error => {
          console.error('Login failed:', error);
          reject(false);
        }
      );
    });
  }

  islogin(){
    var userInfo = localStorage.getItem('user');
    return !!userInfo;
  }
}
