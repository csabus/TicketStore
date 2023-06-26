import { PagingRequest } from '@models';

export interface EventFilterRequest {
  title: string;
  description: string;
  dateFrom: string;
  dateTo: string;
  venueId: string;
  paging: PagingRequest;
}
