using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketStore.API.Dto.Ticket;
using TicketStore.Domain.Enum;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.ActionFilters
{
    public class ValidateTicketCreateAttribute : IActionFilter
    {
        private readonly IEventService _eventService;
        private readonly ITicketTypeService _ticketService;

        public ValidateTicketCreateAttribute(IEventService eventService, ITicketTypeService ticketService)
        {
            _eventService = eventService;
            _ticketService = ticketService;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            CreateTicketsRequest? request = context.ActionArguments.FirstOrDefault().Value as CreateTicketsRequest;
            if(request != null) {
                var theEvent = await _eventService.GetByIdAsync(request.EventId);
                if (theEvent == null)
                {
                    context.ModelState.AddModelError("EventId", "Invalid EventId");
                }

                var ticketType = await _ticketService.GetByIdAsync(request.TicketTypeId);
                if (ticketType == null)
                {
                    context.ModelState.AddModelError("TicketTypeId", "Invalid TicketTypeId");
                }

                if (theEvent?.Venue.Id != ticketType?.Venue.Id)
                {
                    context.ModelState.AddModelError("Venue", "Event.Venue does not match TicketType.Venue");
                }

                if (!string.IsNullOrEmpty(request.Status) && !Enum.TryParse<TicketStatus>(request.Status, true, out _))
                {
                    context.ModelState.AddModelError("Status", "Status is invalid");
                }

            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState));
            }
        }
    }
}
