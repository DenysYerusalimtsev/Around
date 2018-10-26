import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ListBrandComponent } from './list-brand/list-brand.component';
import { DialogBrandComponent } from './dialog-brand/dialog-brand.component';

@NgModule({
  declarations: [
    AppComponent,
    ListBrandComponent,
    DialogBrandComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
