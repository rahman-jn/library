import {Component, Input} from '@angular/core';
import {NgClass, NgIf} from "@angular/common";

@Component({
  selector: 'app-message',
  standalone: true,
  imports: [
    NgIf,
    NgClass
  ],
  templateUrl: './message.component.html',
  styleUrl: './message.component.css'
})
export class MessageComponent {
  @Input() message: string = '';
  @Input() type: 'success' | 'error' = 'success';
  show: boolean = false;

  ngOnInit(): void {
    if (this.message) {
      this.show = true;
      setTimeout(() => {
        this.show = false;
      }, 3000); // Message disappears after 3 seconds
    }
  }

}
