import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListBrandComponent } from './list-brand/list-brand.component';
import { MapComponent } from './map-component/map-component';
import { ListCopterComponent } from './list-copter/list-copter.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: 'brands', component: ListBrandComponent },
  { path: 'map', component: MapComponent },
  { path: 'copters', component: ListCopterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'dashboard', component: DashboardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
