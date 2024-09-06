import { Component, OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { NgIf } from "@angular/common";
import { Router, ActivatedRoute } from '@angular/router';
import { User } from "../models/User";
import { HttpClient } from "@angular/common/http";
import { UserService } from "../services/user/user.service";

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    FormsModule,
    NgIf
  ],
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  user: User = new User(); // Create a new user object
  isEditMode: boolean = false; // Flag to track whether we are updating or creating

  constructor(
    private http: HttpClient,
    private router: Router,
    private userService: UserService,
    private route: ActivatedRoute // ActivatedRoute to get route params
  ) {}

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');
    if (userId) {
      this.isEditMode = true;
      this.loadUser(userId); // Load user data if in edit mode
    }
  }

  // Load the existing user data for update
  loadUser(userId: string): void {
    this.userService.getUserById(userId).subscribe(
      (data: User) => {
        this.user = data;
      },
      (error) => {
        console.error('Error loading user data', error);
      }
    );
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.updateUser();
    } else {
      this.createUser();
    }
  }

  // Method to create a new user
  createUser(): void {
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

  // Method to update an existing user
  updateUser(): void {
    this.userService.updateUser(this.user).subscribe(
      response => {
        console.log('User updated successfully', response);
        this.router.navigate(['/admin']);
      },
      error => {
        console.error('Error updating user', error);
      }
    );
  }

}
