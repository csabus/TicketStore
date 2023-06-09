﻿using AutoMapper;
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
        private readonly ITicketTypeService _ticketTypeService;
        private readonly IVenueService _venueService;
        private readonly IMapper _mapper;

        public TicketTypeController(ITicketTypeService ticketService, IVenueService venueService, IMapper mapper)
        {
            _ticketTypeService = ticketService;
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
                ticketType = await _ticketTypeService.CreateAsync(ticketType);
                return _mapper.Map<TicketType, TicketTypeDetails>(ticketType);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketTypeDetails>> Get(Guid id)
        {
            var ticketType = await _ticketTypeService.GetByIdAsync(id);
            if (ticketType != null)
            {
                return _mapper.Map<TicketType, TicketTypeDetails>(ticketType);
            }

            return NotFound();
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
                ticketType = await _ticketTypeService.UpdateAsync(ticketType);
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
