import {Component} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from "../../shared/store";
import {AuthService} from "../../auth/auth.service";


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  isLoggedIn$ = this.store$.select(store.getAuthLoaded);

  constructor(private readonly store$: Store<store.State>,
              private readonly authService: AuthService) {
  }

  logout() {
    this.authService.logout();
  }

}
