import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {

  constructor() { }

  onSubmit() {
    // For now, we just log the form data to the console
    console.log('Form submitted');
  }

}
