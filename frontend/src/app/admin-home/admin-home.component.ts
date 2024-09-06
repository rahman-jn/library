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
    if (!authService.isAdmin()) {
      console.log("sfdfsdfdsfs")
      this.router.navigate(['/home']);
    }
  }

  async ngOnInit(): Promise<void> {
    try {
      const isAdmin = await this.authService.isAdmin(); // Wait for the async check

      if (!isAdmin) {
        console.log("User is not an admin, redirecting to home...");
        this.router.navigate(['/home']); // Navigate if the user is not an admin
      }
    } catch (error) {
      console.error('Error checking admin status:', error);
      // Handle errors, possibly redirecting to an error page
    }
    this.getUsers();
  }


  getUsers(): void {
    this.userService.getUsers().subscribe(
      (response: any[]) => {
        this.users = response;
      },
      error => {
        console.error('Failed to get users:', error);
      }
    );
  }

  editUser(userId:string){

  }

  deleteUser(userId:string){

  }
  activities(userId:string){

  }
}
