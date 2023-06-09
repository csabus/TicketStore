﻿using AutoMapper;
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
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetails>> Get(Guid id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if(ticket != null)
            {
                return _mapper.Map<Ticket, TicketDetails>(ticket);
            }
            
            return NotFound();
        }

        [HttpGet("validate")]
        public async Task<ActionResult<bool>> Validate([FromQuery] TicketValidationRequest request)
        {
            var result = await _ticketService.ValidateAsync(request.TicketId ?? Guid.Empty, request.EventId ?? Guid.Empty);

            return Ok(result);
        }

        [HttpPost("buy")]
        public async Task<ActionResult<BuyTicketResponse>> Buy(BuyTicketRequest request)
        {
            var ticket = await _ticketService.BuyAsync(request.EventId ?? Guid.Empty, request.TicketTypeId ?? Guid.Empty);
            BuyTicketResponse response;
            if (ticket != null)
            {
                response = new BuyTicketResponse()
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Ticket = _mapper.Map<Ticket, TicketDetails>(ticket)
                };
            }
            else
            {
                response = new BuyTicketResponse()
                {
                    IsSuccess = false,
                    Message = "Error"
                };
            }
            return Ok(response);
        }

        [HttpGet("available/{eventId}")]
        public async Task<ActionResult<AvailableTicketsDetails>> GetAvalialbeTickets(Guid eventId)
        {
            var availableTickets = await _ticketService.GetAvailableTicketsAsync(eventId);
            if(availableTickets != null)
            {
                return _mapper.Map<AvailableTickets, AvailableTicketsDetails>(availableTickets);
            }

            return NotFound();
        }
    }
}
