import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-venue-events',
  templateUrl: './venue-events.component.html',
  styleUrls: ['./venue-events.component.css'],
})
export class VenueEventsComponent implements OnInit {
  venueId = '';

  constructor(private readonly route: ActivatedRoute) {}

  ngOnInit(): void {
    this.venueId = this.route.snapshot.params['id'];
  }
}
