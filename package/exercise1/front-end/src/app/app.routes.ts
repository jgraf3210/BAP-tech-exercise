import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ViewPersonComponent } from './pages/view-person/view-person.component';

export const routes: Routes = [
  { path: '', component: HomeComponent  }, //Homepage route
  { path: 'view', component: ViewPersonComponent },
  { path: '**', component: HomeComponent }
];
