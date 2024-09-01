import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {NgIf} from "@angular/common";
import { Router } from '@angular/router';


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

  constructor(private router: Router) { }

  onSubmit() {
    // For now, we just log the form data to the console
    console.log('Form submitted');
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}
