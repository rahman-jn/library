import {inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);

  login(user: any){
    return this.http.post(`${this.baseUrl}/auth`, user);
  }
}
