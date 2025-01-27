import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  usernameOrEmail: string = '';
  password: string = '';
  errorMessage: string = '';
  successMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.usernameOrEmail, this.password).subscribe({
      next: (response) => {
        this.successMessage = response.message; // Mensaje del backend
        this.errorMessage = ''; // Limpia errores si el login es exitoso
        console.log('Usuario logueado:', response.user);
        this.router.navigate(['/home']); // Redirige a la página /home
      },
      error: (error) => {
        this.successMessage = '';
        this.errorMessage = error.error.message || 'Error al iniciar sesión.';
      },
    });
  }
}
