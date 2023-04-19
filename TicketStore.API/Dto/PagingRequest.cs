using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto
{
    public class PagingRequest
    {
        [Range(0, int.MaxValue)]
        public int? Page { get; set; }
        
        [Range(1, 20)]
        public int? PageSize { get; set; }
    }
}
