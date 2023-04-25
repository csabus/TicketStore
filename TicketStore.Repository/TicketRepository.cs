using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ITicketStoreContext _dbContext;
        public readonly IMapper _mapper;

        public TicketRepository(ITicketStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(Ticket ticket, int count)
        {
            var dbEvent = _dbContext.Events.FirstOrDefault(e => e.Id == ticket.Event.Id);
            var dbTicketType = _dbContext.TicketTypes.FirstOrDefault(t => t.Id == ticket.Type.Id);
            
            if(dbEvent != null && dbTicketType != null)
            {
                for(var i=0; i<count; i++)
                {
                    var dbTicket = _mapper.Map<Ticket, DbTicket>(ticket);
                    dbTicket.Id = Guid.NewGuid();
                    dbTicket.Event = dbEvent;
                    dbTicket.Type = dbTicketType;

                    await _dbContext.Tickets.AddAsync(dbTicket);
                    ((DbContext)_dbContext).Entry(dbTicket.Event).State = EntityState.Unchanged;
                    ((DbContext)_dbContext).Entry(dbTicket.Type).State = EntityState.Unchanged;
                    await ((DbContext)_dbContext).SaveChangesAsync();
                }

                return true;
            }
            
            return false;
        }

    }
}
