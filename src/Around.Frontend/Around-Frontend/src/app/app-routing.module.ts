import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListBrandComponent } from './list-brand/list-brand.component';
import { DialogBrandComponent } from './dialog-brand/dialog-brand.component';
import { GoogleMapComponent } from './google-map/google-map.component';
import { MapComponent } from './map-component/map-component';
import { ListCopterComponent } from './list-copter/list-copter.component';

const routes: Routes = [
  { path: 'brands', component: ListBrandComponent },
  { path: 'map', component: MapComponent },
  { path: 'copters', component: ListCopterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
