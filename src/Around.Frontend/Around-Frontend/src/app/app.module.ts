import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { BrandService } from './service/brand.service';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ListBrandComponent } from './list-brand/list-brand.component';
import { DialogBrandComponent } from './dialog-brand/dialog-brand.component';
import { ApiService, PlacesApiService, StateService } from './core/services';
import { SearchPlaceComponent } from './search-place/search-place.component';
import { SelectPlacesDialogComponent } from './select-places-dialog/select-places-dialog.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { GoogleMapComponent } from './google-map/google-map.component';
import { MapComponent } from './map-component/map-component';
import { ListCopterComponent } from './list-copter/list-copter.component';
import { DialogCopterComponent } from './dialog-copter/dialog-copter.component';
import { CopterService } from './service/copter.service';
import { CopterTableComponent } from './copter-table/copter-table.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

@NgModule({
  declarations: [
    AppComponent,
    ListBrandComponent,
    DialogBrandComponent,
    GoogleMapComponent,
    SearchPlaceComponent,
    SelectPlacesDialogComponent,
    ConfirmDialogComponent,
    MapComponent,
    ListCopterComponent,
    DialogCopterComponent,
    CopterTableComponent,
    LoginComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  entryComponents: [
    DialogBrandComponent,
    DialogCopterComponent
  ],
  providers: [BrandService, ApiService, PlacesApiService, StateService, CopterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
