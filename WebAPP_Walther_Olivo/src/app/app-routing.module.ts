import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../app/components/login/login.component';
import { HomeComponent } from '../app/components/home/home.component';
import { RegistroContableComponent } from './components/registro-contable/registro-contable.component';
import { MovimientoBancarioComponent } from './components/movimiento-bancario/movimiento-bancario.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' }, // Ruta por defecto
  { path: 'login', component: LoginComponent }, // Ruta para el login
  { path: 'home', component: HomeComponent }, // Ruta para la página de inicio
  { path: 'registro-contable', component: RegistroContableComponent },
  { path: 'movimiento-bancario', component: MovimientoBancarioComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
