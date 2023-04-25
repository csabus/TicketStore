using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<bool> CreateAsync(Ticket ticket, int count)
        {
            return _ticketRepository.CreateAsync(ticket, count);
        }
    }
}
