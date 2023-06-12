import { PagingSettings } from './shared/paging-settings-model';

export class ModelBuilder {
  static PagingSettings(): PagingSettings {
    return {
      pageSize: 10,
      length: 0,
      pageSizeOptions: [5, 10, 20],
      pageIndex: 0,
      orderBy: '',
      isDescending: false,
    };
  }
}
