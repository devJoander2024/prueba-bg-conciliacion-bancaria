import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environment'; // Importa las variables de entorno

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = environment.apiUrl; // Usa la variable de entorno

  constructor(private http: HttpClient) {}

  login(usernameOrEmail: string, password: string): Observable<any> {
    const loginData = { UsernameOrEmail: usernameOrEmail, Password: password };
    return this.http.post(`${this.baseUrl}/login`, loginData);
  }
}
