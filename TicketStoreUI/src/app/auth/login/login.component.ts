import {Component} from '@angular/core';
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private readonly authService: AuthService) {
  }

  onLogin() {
    console.log('onLogin');
    this.authService.login();
  }

  onLoginSuccess() {
    console.log('onLoginSuccess');
    this.authService.loginSuccess();
  }

  onLogout() {
    console.log('onLogout');
    this.authService.logout();
  }
}
