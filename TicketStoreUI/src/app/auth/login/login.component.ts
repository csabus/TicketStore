import {Component} from '@angular/core';
import {AuthService} from "../auth.service";
import * as uiActions from '../../shared/store/actions/ui.actions';
import * as store from '../../shared/store'
import {Store} from "@ngrx/store";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private readonly authService: AuthService, private readonly store$: Store<store.State>) {
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
    this.store$.dispatch(uiActions.DoShowMessage({message: 'Test message', action: 'Ok', duration: 2000}));
  }
}
