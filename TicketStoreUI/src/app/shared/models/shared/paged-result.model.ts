export interface PagedResultModel<T> {
  result: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}
