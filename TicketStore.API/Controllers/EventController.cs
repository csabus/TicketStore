using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto;
using TicketStore.API.Dto.Event;
using TicketStore.API.Dto.Venue;
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
        public async Task<ActionResult<EventDetails>> Get(Guid id)
        {
            var eventFound = await _eventService.GetByIdAsync(id);
            if (eventFound != null)
            {
                return _mapper.Map<Event, EventDetails>(eventFound);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<EventDetails>>> GetAll([FromQuery] PagingRequest? pagingRequest)
        {
            var paging = _mapper.Map<PagingRequest, Paging>(pagingRequest ?? new PagingRequest());
            var result = await _eventService.GetPagedAsync(paging);

            return _mapper.Map<PagedResult<Event>, PagedResult<EventDetails>>(result);
        }
        
        [HttpGet("filtered")]
        public async Task<ActionResult<PagedResult<EventDetails>>> GetFiltered([FromQuery] EventFilterRequest? filterRequest)
        {
            var paging = _mapper.Map<PagingRequest, Paging>(filterRequest?.Paging ?? new PagingRequest());
            var filter = _mapper.Map<EventFilterRequest, EventFilter>(filterRequest ?? new EventFilterRequest());

            var result = await _eventService.GetFilteredAsync(paging, filter);

            return _mapper.Map<PagedResult<Event>, PagedResult<EventDetails>>(result);
        }


    }
}
