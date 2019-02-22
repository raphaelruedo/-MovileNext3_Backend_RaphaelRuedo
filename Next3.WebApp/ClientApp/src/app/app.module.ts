import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ListRestaurantComponent } from './pages/restaurant/list-restaurant/list-restaurant.component';
import { ListAddressComponent } from './pages/address/list-address/list-address.component';

import { AngularFontAwesomeModule } from 'angular-font-awesome';

const appRoutes: Routes = [
  { path: 'meus-enderecos', component: ListAddressComponent },
  {
    path: '',
    redirectTo: 'meus-enderecos',
    pathMatch: 'full'
  },
  // { path: 'meus-enderecos/novo', component: RegisterComponent },
  { path: 'restaurantes', component: ListRestaurantComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ListRestaurantComponent,
    ListAddressComponent
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
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
