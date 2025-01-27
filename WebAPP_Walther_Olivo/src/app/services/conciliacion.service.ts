import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environment'; // Importa las variables de entorno

@Injectable({
  providedIn: 'root',
})
export class ConciliacionService {
  private baseUrl = environment.apiUrl; // Usa la variable de entorno
  constructor(private http: HttpClient) {}

  registros(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Conciliacion/registros`);
  }
  movimientos(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Conciliacion/movimientos`);
  }
}
