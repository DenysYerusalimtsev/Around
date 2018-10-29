import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListBrandComponent } from './list-brand/list-brand.component';
import { DialogBrandComponent } from './dialog-brand/dialog-brand.component';

const routes: Routes = [
  { path: 'brands', component: ListBrandComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
