import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
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

  isLogin(): Promise<any> {
    const options = this.getOptions();
    return new Promise((resolve, reject) => {
      this.http.post(`${this.baseUrl}/auth/islogin`, '', options).subscribe(
        response => {
          if(response)
            resolve(true);
          resolve(false)
        },
        error => {
          console.error('Login failed:', error);
          reject(false);
        }
      );
    });
  }

logout(){
    localStorage.removeItem('user');
}
getOptions(){
  const user = localStorage.getItem('user');
  const token = user? JSON.parse(user).token : ''

  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  return {headers: headers};
}

  async isAdmin() {
    if(await this.isLogin()) {
      const userInfoString = localStorage.getItem('user');

      if (userInfoString) {
        const userInfo = JSON.parse(userInfoString); // Parse the JSON string into an object
        return userInfo.roleId === 2;
      }
    }

    return false;
  }

}
