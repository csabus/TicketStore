import {Component, OnInit} from '@angular/core';
import {AuthService} from "../auth.service";
import {UiMessagesService} from "../../shared/ui-messages/ui-messages.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {LoginModel} from "../../shared/models";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm!: FormGroup;

  constructor(private readonly authService: AuthService,
              private readonly formBuilder: FormBuilder,
              private readonly uiMessageService: UiMessagesService,
              private readonly router: Router) {
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      this.authService.login({
        username: this.loginForm.value.username,
        password: this.loginForm.value.password
      }).subscribe((user) => {
        if (user) {
          this.router.navigate(['']).then();
        }
      });
    }
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
