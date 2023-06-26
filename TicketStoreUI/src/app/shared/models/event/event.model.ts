import { VenueModel } from '@models';

export interface EventModel {
  id: string;
  title: string;
  description: string;
  dateTime: Date;
  venue: VenueModel;
}
