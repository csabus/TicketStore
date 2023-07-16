import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagingRequest, PagingSettings, VenueModel } from '@models';
import { ModelBuilder } from '@models/model-builder';
import { EventModel } from '@models/event/event.model';
import { VenueService } from '../venue.service';
import { EventFilterRequest } from '@models/event/event-filter-request.model';

@Component({
  selector: 'app-venue-events',
  templateUrl: './venue-events.component.html',
  styleUrls: ['./venue-events.component.css'],
})
export class VenueEventsComponent implements OnInit {
  venueId = '';
  pagingSettings: PagingSettings = ModelBuilder.PagingSettings();

  venue?: VenueModel;
  eventList: EventModel[] = [];

  constructor(
    private readonly route: ActivatedRoute,
    private readonly venueService: VenueService
  ) {}

  ngOnInit(): void {
    this.venueId = this.route.snapshot.params['id'];
    this.loadVenue();
    this.loadEvents();
  }

  loadVenue(): void {
    this.venueService
      .getVenueDetails(this.venueId)
      .subscribe((venue) => (this.venue = venue));
  }

  loadEvents(): void {
    const eventFilter: EventFilterRequest = {
      title: '',
      description: '',
      dateFrom: '',
      dateTo: '',
      venueId: this.venueId,
      paging: {
        page: this.pagingSettings.pageIndex,
        pageSize: this.pagingSettings.pageSize,
        orderBy: this.pagingSettings.orderBy,
        isDescending: this.pagingSettings.isDescending,
      },
    };
    this.venueService.getEvents(eventFilter).subscribe((result) => {
      this.pagingSettings.pageIndex = result.page;
      this.pagingSettings.pageSize = result.pageSize;
      this.pagingSettings.length = result.totalCount;
      console.log(result);
      this.eventList = result.result;
    });
  }
}
