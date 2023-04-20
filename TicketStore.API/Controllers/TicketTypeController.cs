using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto.Ticket;
using TicketStore.Domain;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IVenueService _venueService;
        private readonly IMapper _mapper;

        public TicketTypeController(ITicketService ticketService, IVenueService venueService, IMapper mapper)
        {
            _ticketService = ticketService;
            _venueService = venueService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<TicketTypeDetails>> Create(CreateTicketTypeRequest createTicketTypeRequest)
        {
            var ticketType = _mapper.Map<CreateTicketTypeRequest, TicketType>(createTicketTypeRequest);
            var venue = await _venueService.GetByIdAsync(createTicketTypeRequest.VenueId);
            if (venue != null)
            {
                ticketType.Venue = venue;
                ticketType = await _ticketService.CreateTypeAsync(ticketType);
                return _mapper.Map<TicketType, TicketTypeDetails>(ticketType);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketTypeDetails>> Get(string id)
        {
            if (Guid.TryParseExact(id, "D", out var ticketTypeId))
            {
                var ticketType = await _ticketService.GetTypeByIdAsync(ticketTypeId);
                if (ticketType != null)
                {
                    return _mapper.Map<TicketType, TicketTypeDetails>(ticketType);
                }

                return NotFound();
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<TicketTypeDetails>> Update(UpdateTicketTypeRequest updateRequest)
        {
            var ticketType = _mapper.Map<UpdateTicketTypeRequest, TicketType>(updateRequest);
            var venue = await _venueService.GetByIdAsync(updateRequest.VenueId);
            if (venue != null)
            {
                ticketType.Venue = venue;
                ticketType = await _ticketService.UpdateTypeAsync(ticketType);
                if (ticketType != null)
                {
                    return _mapper.Map<TicketType, TicketTypeDetails>(ticketType);
                }

                return NotFound();
            }

            return NotFound();
        }


    }
}
