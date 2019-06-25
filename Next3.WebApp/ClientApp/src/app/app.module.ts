import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {NgxMaskModule} from 'ngx-mask'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ListRestaurantComponent } from './pages/restaurant/list-restaurant/list-restaurant.component';
import { ListAddressComponent } from './pages/address/list-address/list-address.component';

import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { HomeComponent } from './pages/home/home.component';
import { GooglePlaceModule } from "ngx-google-places-autocomplete";

const appRoutes: Routes = [
  { path: 'meus-enderecos', component: ListAddressComponent },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  { path: 'restaurantes', component: ListRestaurantComponent },
  { path: 'home', component: HomeComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListRestaurantComponent,
    ListAddressComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false }
    ),
    BrowserAnimationsModule,
    AngularFontAwesomeModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    NgxMaskModule.forRoot(),
    GooglePlaceModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
