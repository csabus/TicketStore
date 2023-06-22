namespace TicketStore.API.Dto.Event
{
    public class EventFilterRequest
    {

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
        
        public Guid? VenueId { get; set; }

        public PagingRequest? Paging { get; set; }

    }
}
