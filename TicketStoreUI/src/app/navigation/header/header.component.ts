import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import * as store from '@store';
import { AuthService } from '../../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  isLoggedIn$ = this.store$.select(store.getAuthLoaded);
  user$ = this.store$.select(store.getLoggedUser);

  constructor(
    private readonly store$: Store<store.State>,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {}

  logout() {
    this.authService.logout();
    this.router.navigate(['']).then();
  }
}
