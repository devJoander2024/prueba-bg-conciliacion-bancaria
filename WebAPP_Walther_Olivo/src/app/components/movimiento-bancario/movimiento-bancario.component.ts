import { Component } from '@angular/core';
import { ConciliacionService } from 'src/app/services/conciliacion.service';

@Component({
  selector: 'app-movimiento-bancario',
  templateUrl: './movimiento-bancario.component.html',
  styleUrls: ['./movimiento-bancario.component.css'],
})
export class MovimientoBancarioComponent {
  movimientos: any[] = []; // Para almacenar los Movimientos obtenidos
  errorMessage: string = '';
  successMessage: string = '';

  constructor(private conciliacionService: ConciliacionService) {}
  ngOnInit() {
    this.getMovimientos();
  }
  getMovimientos() {
    this.conciliacionService.movimientos().subscribe({
      next: (response) => {
        this.movimientos = response.data || []; // Almacena los Movimientos si la respuesta es exitosa
        this.successMessage = 'Movimientos obtenidos exitosamente.';
        this.errorMessage = ''; // Limpia el error si la consulta es exitosa
      },
      error: (error) => {
        this.movimientos = [];
        this.successMessage = '';
        this.errorMessage =
          error.error.message || 'Error al obtener los Movimientos.';
      },
    });
  }
}
