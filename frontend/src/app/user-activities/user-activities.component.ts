import {Component, OnInit, Pipe} from '@angular/core';
import {CommonModule, NgForOf} from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user/user.service';
import {UserBook} from "../models/UserBook";
import {MessageComponent} from "../message/message.component";


interface Book {
  name: string;
}


@Component({
  selector: 'app-user-activities',
  standalone: true,
  imports: [NgForOf, CommonModule],
  templateUrl: './user-activities.component.html',
  styleUrls: ['./user-activities.component.css']
})
export class UserActivitiesComponent  {
  userId: string | null = null; // Variable to store the user ID from the route
  activities: UserBook[] = []; // Array to store the fetched reservations

  constructor(
    private route: ActivatedRoute,
    private userService: UserService // Assume a UserService is used to fetch user activities
  ) {}

  ngOnInit(): void {
    // Get the userId from the route
    this.userId = this.route.snapshot.paramMap.get('id');

    if (this.userId) {
      // Fetch user activities using the ID
      this.userService.getUserActivities(this.userId).subscribe(
        (data: UserBook[]) => {
          this.activities = data; // Assign the fetched data to the reservations array
        },
        (error) => {
          console.error('Error fetching reservations:', error);
        }
      );
    }
  }
}
