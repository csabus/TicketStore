import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VenuesComponent } from './venues/venues.component';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [VenuesComponent],
  imports: [CommonModule, MatPaginatorModule],
})
export class VenuesModule {}
