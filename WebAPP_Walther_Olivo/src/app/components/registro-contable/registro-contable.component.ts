import { Component } from '@angular/core';
import { ConciliacionService } from 'src/app/services/conciliacion.service';

@Component({
  selector: 'app-registro-contable',
  templateUrl: './registro-contable.component.html',
  styleUrls: ['./registro-contable.component.css'],
})
export class RegistroContableComponent {
  registros: any[] = []; // Para almacenar los registros obtenidos
  errorMessage: string = '';
  successMessage: string = '';

  constructor(private conciliacionService: ConciliacionService) {}
  ngOnInit() {
    this.getRegistros();
  }
  getRegistros() {
    this.conciliacionService.registros().subscribe({
      next: (response) => {
        // Verifica si la respuesta es un array de registros
        this.registros = response || []; // Si no hay 'data', solo usa la respuesta
        this.successMessage = 'Registros obtenidos exitosamente.';
        this.errorMessage = ''; // Limpia el error si la consulta es exitosa
      },
      error: (error) => {
        this.registros = [];
        this.successMessage = '';
        this.errorMessage =
          error.error.message || 'Error al obtener los registros.';
      },
    });
  }
}
