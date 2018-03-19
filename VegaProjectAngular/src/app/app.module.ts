import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { NavMenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'vehicle/new', component: VehicleFormComponent },
      { path: 'vehicle/:id', component: VehicleFormComponent},
      { path: '**', redirectTo: 'home' }
  ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
