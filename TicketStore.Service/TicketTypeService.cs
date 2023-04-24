using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _ticketRepository;

        public TicketTypeService(ITicketTypeRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<TicketType> CreateAsync(TicketType ticketType)
        {
            return _ticketRepository.CreateAsync(ticketType);
        }

        public Task<TicketType> GetByIdAsync(Guid? id)
        {
            return _ticketRepository.GetByIdAsync(id);
        }

        public Task<TicketType> UpdateAsync(TicketType ticketType)
        {
            return _ticketRepository.UpdateAsync(ticketType);
        }
    }
}
