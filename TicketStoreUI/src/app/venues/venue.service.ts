import { Injectable } from '@angular/core';
import * as store from '../shared/store';
import * as uiActions from '../shared/store/actions/ui.actions';
import { environment } from '../../environments/environment';
import { Store } from '@ngrx/store';
import { HttpClient } from '@angular/common/http';
import { PagingRequestModel } from '../shared/models';
import { Observable, tap } from 'rxjs';
import { PagedResultModel } from '../shared/models';
import { VenueModel } from '../shared/models/';

@Injectable({
  providedIn: 'root',
})
export class VenueService {
  constructor(
    private readonly store$: Store<store.State>,
    private readonly http: HttpClient
  ) {}

  getAll(paging: PagingRequestModel): Observable<PagedResultModel<VenueModel>> {
    this.store$.dispatch(uiActions.DoStartLoading());
    const url =
      `${environment.api.url}/venue?` +
      `page=${paging.page}&` +
      `pageSize=${paging.pageSize}&` +
      `orderBy=${paging.orderBy}&` +
      `isDescending=${paging.isDescending}`;
    return this.http
      .get<PagedResultModel<VenueModel>>(url)
      .pipe(tap(() => this.store$.dispatch(uiActions.DoStopLoading())));
  }
}
