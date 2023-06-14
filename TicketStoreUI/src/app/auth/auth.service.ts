import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import * as store from '@store';
import * as authActions from '@store/actions/auth.actions';
import * as uiActions from '@store/actions/ui.actions';
import { LoginModel, UserModel } from '@models';
import { environment } from '../../environments/environment';
import { UiMessagesService } from '../shared/ui-messages/ui-messages.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private readonly store$: Store<store.State>,
    private readonly http: HttpClient,
    private readonly uiMessageService: UiMessagesService
  ) {
    this.loadUserFromLocalStorage();
  }

  private loadUserFromLocalStorage() {
    const user = JSON.parse(
      localStorage.getItem('ticket-store-user') ?? '{}'
    ) as UserModel;
    if (user.username) {
      this.store$.dispatch(authActions.DoLoginSuccess(user));
    }
  }

  login(loginModel: LoginModel): Observable<UserModel | null> {
    this.store$.dispatch(uiActions.DoStartLoading());
    this.store$.dispatch(authActions.DoLogin());
    return this.http
      .post<UserModel>(`${environment.api.url}/account/login`, loginModel)
      .pipe(
        map((user: UserModel) => {
          this.store$.dispatch(authActions.DoLoginSuccess(user));
          this.store$.dispatch(uiActions.DoStopLoading());
          localStorage.setItem('ticket-store-user', JSON.stringify(user));
          return user;
        }),
        catchError((error) => {
          this.store$.dispatch(authActions.DoLoginFail());
          this.store$.dispatch(uiActions.DoStopLoading());
          this.uiMessageService.showMessage(
            'Authentication failed',
            'Ok',
            5000
          );
          return of(null);
        })
      );
  }

  loginSuccess() {
    //this.store$.dispatch(authActions.DoLoginSuccess({id: '1', userName: 'csabus'}));
  }

  logout() {
    this.store$.dispatch(authActions.DoLogout());
    localStorage.removeItem('ticket-store-user');
  }
}
