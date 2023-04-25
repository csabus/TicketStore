using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.ActionFilters;
using TicketStore.API.Dto.Ticket;
using TicketStore.Domain;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IVenueService _venueService;
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(IEventService eventService, IVenueService venueService, ITicketService ticketService, IMapper mapper)
        {
            _eventService = eventService;
            _venueService = venueService;
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateTicketCreateAttribute))]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult> Create(CreateTicketsRequest request)
        {
            var ticket = _mapper.Map<CreateTicketsRequest, Ticket>(request);

            var result = await _ticketService.CreateAsync(ticket, request.Count ?? 0);
            if(result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
