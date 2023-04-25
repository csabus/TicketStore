using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto;
using TicketStore.API.Dto.Venue;
using TicketStore.Domain;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;
        private readonly IMapper _mapper;

        public VenueController(IVenueService venueService, IMapper mapper)
        {
            _venueService = venueService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<VenueDetails>> Create(CreateVenueRequest createVenueRequest)
        {
            var venue = _mapper.Map<CreateVenueRequest, Venue>(createVenueRequest);

            venue = await _venueService.CreateAsync(venue);

            if(venue != null)
            {
                return Ok(venue);
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<ActionResult<VenueDetails>> Update(UpdateVenueRequest updateVenueRequest)
        {
            var venue = _mapper.Map<UpdateVenueRequest, Venue>(updateVenueRequest);
            venue = await _venueService.UpdateAsync(venue);
            if(venue != null)
            {
                return _mapper.Map<Venue, VenueDetails>(venue);
            }
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VenueDetails>> Get(Guid id)
        {
            var venue = await _venueService.GetByIdAsync(id);
            if (venue != null)
            {
                return _mapper.Map<Venue, VenueDetails>(venue);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<VenueDetails>>> GetAll([FromQuery] PagingRequest? pagingRequest)
        {
            var paging = _mapper.Map<PagingRequest, Paging>(pagingRequest ?? new PagingRequest());
            var result = await _venueService.GetPagedAsync(paging);

            return _mapper.Map<PagedResult<Venue>, PagedResult<VenueDetails>>(result);
        }


    }
}
