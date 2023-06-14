import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { VenuesComponent } from './venues/venues.component';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [VenuesComponent],
  exports: [VenuesComponent],
  imports: [CommonModule, MatPaginatorModule, SharedModule],
})
export class VenuesModule {}
