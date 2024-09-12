import { Component } from '@angular/core';
import {NgForOf} from "@angular/common";
import {AuthService} from "../services/auth/auth.service";
import {Router} from "@angular/router";
import {BookService} from "../services/book/book.service";
import {UserService} from "../services/user/user.service";

@Component({
  selector: 'app-admin-home',
  standalone: true,
    imports: [
        NgForOf
    ],
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.css'
})
export class AdminHomeComponent {
  users: any[] = [];
  constructor(private authService: AuthService, private router: Router, private userService: UserService) {

  }

  async ngOnInit(): Promise<void> {

    try {
      const isAdmin = await this.authService.isAdmin().then(response => {
        if (!response) {
          console.log("User is not an admin, redirecting to home...");
          this.router.navigate(['/home']);
        }
      }
    )

    } catch (error) {
      console.error('Error checking admin status:', error);
      // Handle errors, possibly redirecting to an error page
    }
    this.getUsers();
  }


  getUsers(): void {
    this.userService.getUsers().then(
      users => this.users = users
    );
  }

  editUser(userId: string) {
    // Navigate to the registration (edit) page with the userId in the route
    this.router.navigate(['/edit-user', userId]);
  }

  activities(userId:string){
    this.router.navigate(['/activities', userId]);

  }
}
