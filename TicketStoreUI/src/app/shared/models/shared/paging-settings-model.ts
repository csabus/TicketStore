export interface PagingSettings {
  length: number;
  pageSize: number;
  pageSizeOptions: number[];
  pageIndex: number;
  orderBy: string;
  isDescending: boolean;
}
