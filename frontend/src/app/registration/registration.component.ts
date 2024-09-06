import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {NgIf} from "@angular/common";
import { Router } from '@angular/router';
import {User} from "../models/User";
import {HttpClient} from "@angular/common/http";
import {UserService} from "../services/user/user.service";


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    FormsModule,
    NgIf
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  user: User = new User(); // Create a new user object

  constructor(private http: HttpClient, private router: Router, private userService:UserService) {}

  onSubmit() {
    console.log(this.user)
    this.userService.createUser(this.user).subscribe(
      response => {
        console.log('User registered successfully', response);
        this.router.navigate(['/admin']);
      },
      error => {
        console.error('Error registering user', error);
      }
    );
  }


  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
