import {Injectable} from '@angular/core';
import {HttpRequest, HttpHandler, HttpEvent, HttpInterceptor} from '@angular/common/http';
import {first, mergeMap, Observable} from 'rxjs';
import {environment} from '../../../environments';
import {Store} from "@ngrx/store";
import * as store from '../store';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private readonly store$: Store<store.State>) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return this.store$.select(store.getToken).pipe(
      first(),
      mergeMap((token) => {
        const isApiUrl = request.url.startsWith(environment.api.url);
        const authRequest = !!token && isApiUrl ? request.clone({
          setHeaders: {Authorization: `Bearer ${token}`},
        }) : request;
        return next.handle(authRequest);
      })
    );
  }
}
