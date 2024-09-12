import { Routes } from '@angular/router';
import {RegistrationComponent} from "./registration/registration.component";
import {LoginComponent} from "./login/login.component";
import {HomeComponent} from "./home/home.component";
import {AdminHomeComponent} from "./admin-home/admin-home.component";
import {UserActivitiesComponent} from "./user-activities/user-activities.component";

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  {
    path: 'edit-user/:id',
    component: RegistrationComponent
  },
  { path: 'home', component: HomeComponent },
  { path: 'admin', component: AdminHomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'activities/:id', component: UserActivitiesComponent },
  // { path: '**', redirectTo: '/login' }
];
