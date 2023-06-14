export interface PagedResult<T> {
  result: T[];
  totalCount: number;
  page: number;
  pageSize: number;
}
