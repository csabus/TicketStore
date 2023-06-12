import { AddressModel } from '../shared/address-model';

export interface VenueModel {
  id: string;
  name: string;
  description: string;
  address: AddressModel;
}
