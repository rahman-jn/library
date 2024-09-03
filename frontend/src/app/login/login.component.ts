import {Component, inject} from '@angular/core';
import { Router } from '@angular/router';
import {FormsModule} from "@angular/forms";
import {AuthService} from "../services/auth/auth.service";
import * as http from "http";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {response} from "express";
import {NgIf} from "@angular/common";
import {catchError} from "rxjs/operators";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    NgIf
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private authService: AuthService, private router: Router) {

  }
  private baseUrl = 'http://localhost:5048/api';
  http = inject(HttpClient);

  onSubmit(form: any): void {
    if (form.valid) {
      const user = {
        email: form.value.email,
        password: form.value.password
      };
      this.authService.login(user).then(isLoggedIn => {
        this.router.navigate(['/home']);
      })

    }
  }

  navigateToRegistration() {
    this.router.navigate(['/register']);
  }
}
