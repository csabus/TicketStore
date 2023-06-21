import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { VenueService } from '../venue.service';
import { PagingRequest, PagingSettings, VenueModel } from '@models';
import { ModelBuilder } from '@models/model-builder';

@Component({
  selector: 'app-venue-list',
  templateUrl: './venue-list.component.html',
  styleUrls: ['./venue-list.component.css'],
})
export class VenueListComponent implements OnInit {
  pagingSettings: PagingSettings = ModelBuilder.PagingSettings();
  venueList: VenueModel[] = [];

  constructor(private readonly venueService: VenueService) {}

  ngOnInit(): void {
    this.loadVenues();
  }

  loadVenues(): void {
    const pagingRequest: PagingRequest = {
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
      this.venueList = result.result;
    });
  }

  onPageEvent(e: PageEvent) {
    this.pagingSettings.pageSize = e.pageSize;
    this.pagingSettings.pageIndex = e.pageIndex;
    this.loadVenues();
  }
}
