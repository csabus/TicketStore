namespace TicketStore.Domain
{
    public class Paging
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string? OrderBy { get; set; }

        public bool IsDescending { get; set; }

        public string GetOrderByString(string defaultOrderBy)
        {
            if(string.IsNullOrEmpty(OrderBy))
            {
                return defaultOrderBy;
            }

            return OrderBy + (IsDescending ? " desc" : " asc");
        }
    }
}
