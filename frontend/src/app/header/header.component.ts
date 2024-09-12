import { Component } from '@angular/core';
import {Router, RouterLink} from "@angular/router";
import {AuthService} from "../services/auth/auth.service";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    RouterLink,
    NgIf
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent  {
  isLoggedIn: void | boolean = false;
  isAdmin = false;

  constructor(private authService: AuthService, private router: Router) { }

  async ngOnInit(): Promise<void> {
    // Check if the user is logged in
    this.isLoggedIn = await this.authService.isLogin().then( response => {
      this.isLoggedIn = response
      if(this.isLoggedIn)
        this.authService.isAdmin().then(response => {
          this.isAdmin = response;
        });
    });

  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
