import { Component } from '@angular/core';
import { ConciliacionService } from 'src/app/services/conciliacion.service';

@Component({
  selector: 'app-registro-contable',
  templateUrl: './registro-contable.component.html',
  styleUrls: ['./registro-contable.component.css'],
})
export class RegistroContableComponent {
  errorMessage: string = '';
  successMessage: string = '';
  constructor(private authService: ConciliacionService) {}

  getRegistros() {
    this.authService.registros().subscribe({
      next: (response) => {
        this.successMessage = response.message; // Mensaje del backend
        this.errorMessage = ''; // Limpia errores si el login es exitoso
      },
      error: (error) => {
        this.successMessage = '';
        this.errorMessage = error.error.message || 'Error al iniciar sesión.';
      },
    });
  }
}
