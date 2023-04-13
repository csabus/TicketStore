using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    }
}
