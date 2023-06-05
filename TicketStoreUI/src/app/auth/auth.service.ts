import {Injectable} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from "../shared/store";
import * as authActions from '../shared/store/actions/auth.actions';
import * as uiActions from '../shared/store/actions/ui.actions';
import {LoginModel} from "../shared/models";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private store$: Store<store.State>) {
  }

  login(loginModel: LoginModel) {
    this.store$.dispatch(uiActions.DoStartLoading());
    setTimeout(() => {
      this.store$.dispatch(uiActions.DoStopLoading())
    }, 2000);
    this.store$.dispatch(authActions.DoLogin());
  }

  loginSuccess() {
    this.store$.dispatch(authActions.DoLoginSuccess({id: '1', userName: 'csabus'}));
  }

  logout() {
    this.store$.dispatch(authActions.DoLogout());
  }
}
