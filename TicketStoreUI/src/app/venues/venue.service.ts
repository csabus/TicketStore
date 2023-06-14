import { Injectable } from '@angular/core';
import * as store from '../shared/store';
import * as uiActions from '../shared/store/actions/ui.actions';
import { environment } from '../../environments/environment';
import { Store } from '@ngrx/store';
import { HttpClient } from '@angular/common/http';
import { PagingRequest, PagedResult, VenueModel } from '@models';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VenueService {
  constructor(
    private readonly store$: Store<store.State>,
    private readonly http: HttpClient
  ) {}

  getAll(paging: PagingRequest): Observable<PagedResult<VenueModel>> {
    this.store$.dispatch(uiActions.DoStartLoading());
    const url =
      `${environment.api.url}/venue?` +
      `page=${paging.page}&` +
      `pageSize=${paging.pageSize}&` +
      `orderBy=${paging.orderBy}&` +
      `isDescending=${paging.isDescending}`;
    return this.http
      .get<PagedResult<VenueModel>>(url)
      .pipe(tap(() => this.store$.dispatch(uiActions.DoStopLoading())));
  }
}
