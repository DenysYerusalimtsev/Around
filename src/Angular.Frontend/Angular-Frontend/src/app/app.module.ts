import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListBrandComponent } from './list-brand/list-brand/list-brand.component';
import { ListClientComponent } from './list-client/list-client.component';
import { ListRentComponent } from './list-rent/list-rent.component';
import { ListChequeComponent } from './list-cheque/list-cheque.component';
import { ListCopterComponent } from './list-copter/list-copter.component';

@NgModule({
  declarations: [
    AppComponent,
    ListBrandComponent,
    ListClientComponent,
    ListRentComponent,
    ListChequeComponent,
    ListCopterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
