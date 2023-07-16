import { Injectable } from '@angular/core';
import * as store from '../shared/store';
import * as uiActions from '../shared/store/actions/ui.actions';
import { environment } from '../../environments/environment';
import { Store } from '@ngrx/store';
import { HttpClient } from '@angular/common/http';
import { PagingRequest, PagedResult, VenueModel } from '@models';
import { Observable, tap } from 'rxjs';
import { EventFilterRequest } from '@models/event/event-filter-request.model';
import { EventModel } from '@models/event/event.model';

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

  getEvents(
    evenFilter: EventFilterRequest
  ): Observable<PagedResult<EventModel>> {
    this.store$.dispatch(uiActions.DoStartLoading());
    const url =
      `${environment.api.url}/event/filtered?` +
      `page=${evenFilter.paging.page}&` +
      `pageSize=${evenFilter.paging.pageSize}&` +
      `orderBy=${evenFilter.paging.orderBy}&` +
      `isDescending=${evenFilter.paging.isDescending}&` +
      `title=${evenFilter.title}&` +
      `description=${evenFilter.description}&` +
      `dateFrom=${evenFilter.dateFrom}&` +
      `dateTo=${evenFilter.dateTo}&` +
      `venueId=${evenFilter.venueId}`;
    return this.http
      .get<PagedResult<EventModel>>(url)
      .pipe(tap(() => this.store$.dispatch(uiActions.DoStopLoading())));
  }

  getVenueDetails(id: string): Observable<VenueModel> {
    this.store$.dispatch(uiActions.DoStartLoading());
    const url = `${environment.api.url}/venue/${id}`;
    return this.http
      .get<VenueModel>(url)
      .pipe(tap(() => this.store$.dispatch(uiActions.DoStopLoading())));
  }
}
