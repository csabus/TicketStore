import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { VenueListComponent } from './venue-list/venue-list.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { VenueEventsComponent } from './venue-events/venue-events.component';
import { RouterLink } from '@angular/router';

@NgModule({
  declarations: [VenueListComponent, VenueEventsComponent],
  exports: [VenueListComponent],
  imports: [CommonModule, MatPaginatorModule, SharedModule, RouterLink],
})
export class VenuesModule {}
