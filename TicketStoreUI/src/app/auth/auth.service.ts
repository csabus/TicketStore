import {Injectable} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from "../shared/store";
import * as authActions from '../shared/store/actions/auth.actions';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private store$: Store<store.State>) {
  }

  login() {
    this.store$.dispatch(authActions.DoLogin());
  }

  loginSuccess() {
    this.store$.dispatch(authActions.DoLoginSuccess({id: '1', userName: 'csabus'}));
  }

  logout() {
    this.store$.dispatch(authActions.DoLogout());
  }
}
