import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
  { path: 'home', loadComponent: () => HomeComponent  }, //Homepage route
  { path: '', redirectTo: '/home', pathMatch:'full'} //Default route redirects back to home if the route isn't defined

];
