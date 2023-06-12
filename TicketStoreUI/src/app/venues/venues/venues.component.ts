import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { VenueService } from '../venue.service';
import { PagingRequestModel } from '../../shared/models';
import { PagingSettings } from '../../shared/models';
import { ModelBuilder } from '../../shared/models/model-builder';

@Component({
  selector: 'app-venues',
  templateUrl: './venues.component.html',
  styleUrls: ['./venues.component.css'],
})
export class VenuesComponent implements OnInit {
  pagingSettings: PagingSettings = ModelBuilder.PagingSettings();

  constructor(private readonly venueService: VenueService) {}

  ngOnInit(): void {
    this.loadVenues();
  }

  loadVenues(): void {
    const pagingRequest: PagingRequestModel = {
      page: this.pagingSettings.pageIndex,
      pageSize: this.pagingSettings.pageSize,
      orderBy: this.pagingSettings.orderBy,
      isDescending: this.pagingSettings.isDescending,
    };
    this.venueService.getAll(pagingRequest).subscribe((result) => {
      this.pagingSettings.pageIndex = result.page;
      this.pagingSettings.pageSize = result.pageSize;
      this.pagingSettings.length = result.totalCount;
      console.log(result);
    });
  }

  onPageEvent(e: PageEvent) {
    this.pagingSettings.pageSize = e.pageSize;
    this.pagingSettings.pageIndex = e.pageIndex;
    this.loadVenues();
  }
}
