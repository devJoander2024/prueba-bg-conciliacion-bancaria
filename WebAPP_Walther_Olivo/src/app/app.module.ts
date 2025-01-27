import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegistroContableComponent } from './components/registro-contable/registro-contable.component';
import { MovimientoBancarioComponent } from './components/movimiento-bancario/movimiento-bancario.component';

@NgModule({
  declarations: [AppComponent, LoginComponent, HomeComponent, RegistroContableComponent, MovimientoBancarioComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
