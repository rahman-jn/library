import {inject, Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AuthService} from "../auth/auth.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private router: Router, private authService: AuthService) {}
  private baseUrl = 'http://localhost:5048';
  http = inject(HttpClient);

  getUsers(): Promise<any>
  {
    const options = this.authService.getOptions();
    return new Promise((resolve, reject) => {
      this.http.get(`${this.baseUrl}/admin/user/list`, options).subscribe(
        response => {
          if(response)
            resolve(response);
          resolve([])
        },
        error => {
          console.error('Error:', error);
          reject([]);
        }
      );
    });
  }

  createUser(user:any){
    const options = this.authService.getOptions();
    return this.http.post(`${this.baseUrl}/admin/user`, user, options);

  }

}
