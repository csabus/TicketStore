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

        public Task<TicketType> CreateTypeAsync(TicketType ticketType)
        {
            return _ticketRepository.CreateTypeAsync(ticketType);
        }

        public Task<TicketType> GetTypeByIdAsync(Guid id)
        {
            return _ticketRepository.GetTypeByIdAsync(id);
        }

        public Task<TicketType> UpdateTypeAsync(TicketType ticketType)
        {
            return _ticketRepository.UpdateypeAsync(ticketType);
        }
    }
}
