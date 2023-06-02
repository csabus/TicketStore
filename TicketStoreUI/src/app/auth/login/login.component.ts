import {Component} from '@angular/core';
import {AuthService} from "../auth.service";
import {UiMessagesService} from "../../shared/ui-messages/ui-messages.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private readonly authService: AuthService,
              private readonly uiMessageService: UiMessagesService) {
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

  onShowMessage() {
    this.uiMessageService.showMessage('Test message', 'Ok', 2000);
  }
}
