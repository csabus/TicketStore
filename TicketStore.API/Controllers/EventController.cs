﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto.Event;
using TicketStore.Domain;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IVenueService _venueService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IVenueService venueService, IMapper mapper)
        {
            _eventService = eventService;
            _venueService = venueService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<EventDetails>> Create(CreateEventRequest createEventRequest)
        {
            var newEvent = _mapper.Map<CreateEventRequest, Event>(createEventRequest);
            var venue = await _venueService.GetByIdAsync(createEventRequest.VenueId);
            if(venue != null)
            {
                newEvent.Venue = venue;
                newEvent = await _eventService.CreateAsync(newEvent);
                return _mapper.Map<Event, EventDetails>(newEvent);
            }

            return NotFound();
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<EventDetails>> Update(UpdateEventRequest updateEventRequest)
        {
            var eventToUpdate = _mapper.Map<UpdateEventRequest, Event>(updateEventRequest);
            var venue = await _venueService.GetByIdAsync(updateEventRequest.VenueId);
            if (venue != null)
            {
                eventToUpdate.Venue = venue;
                eventToUpdate = await _eventService.UpdateAsync(eventToUpdate);
                if(eventToUpdate != null)
                {
                    return _mapper.Map<Event, EventDetails>(eventToUpdate);
                }
                
                return NotFound();
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetails>> Get(string id)
        {
            if (Guid.TryParseExact(id, "D", out var eventId))
            {
                var eventFound = await _eventService.GetByIdAsync(eventId);
                if (eventFound != null)
                {
                    return _mapper.Map<Event, EventDetails>(eventFound);
                }

                return NotFound();
            }

            return BadRequest();
        }



    }
}
