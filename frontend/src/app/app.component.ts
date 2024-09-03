import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {RegistrationComponent} from "./registration/registration.component";
import {LoginComponent} from "./login/login.component";
import {SidebarComponent} from "./sidebar/sidebar.component";
import {HeaderComponent} from "./header/header.component";
import { HttpClientModule } from '@angular/common/http';
import {MessageComponent} from "./message/message.component";
import {MessageService} from "./services/message/message.service";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RegistrationComponent, LoginComponent, SidebarComponent, HeaderComponent, MessageComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  message: string = '';
  messageType: 'success' | 'error' = 'success';

  constructor(private messageService: MessageService) {}

  ngOnInit(): void {
    this.messageService.message$.subscribe(msg => {
      if (msg) {
        this.message = msg.message;
        this.messageType = msg.type;
      } else {
        this.message = '';
      }
    });
  }
}
