using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Domain.Enum;
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

        public Task<Ticket> GetByIdAsync(Guid id)
        {
            var dbTicket = _dbContext.Tickets
                .Where(t => t.Id == id)
                .Include(t => t.Event)
                .Include(t => t.Type)
                .FirstOrDefault();
            
            if (dbTicket != null)
            {
                return Task.FromResult(_mapper.Map<DbTicket, Ticket>(dbTicket));
            }

            return Task.FromResult<Ticket>(null!);
        }

        public Task<bool> ValidateAsync(Guid ticketId, Guid eventId)
        {
            var dbTicket = _dbContext.Tickets
                .Where(t => t.Id == ticketId)
                .Include(t => t.Event)
                .FirstOrDefault();

            var isValid = dbTicket != null && 
                dbTicket.Event.Id == eventId && 
                dbTicket.Status == (int)TicketStatus.Sold;

           return Task.FromResult(isValid);
        }

        public async Task<Ticket> BuyAsync(Guid eventId, Guid ticketTypeId)
        {
            using var tranaction = ((DbContext)_dbContext).Database.BeginTransaction();
            try
            {
                var dbTicket = _dbContext.Tickets
                    .Where(t => t.Event.Id == eventId)
                    .Where(t => t.Type.Id == ticketTypeId)
                    .Where(t => t.Status == (int)TicketStatus.Available)
                    .Include(t => t.Event)
                    .Include(t => t.Type)
                    .FirstOrDefault();

                if(dbTicket != null)
                {
                    dbTicket.Status = (int)TicketStatus.Sold;
                    
                    ((DbContext)_dbContext).Entry(dbTicket.Event).State = EntityState.Unchanged;
                    ((DbContext)_dbContext).Entry(dbTicket.Type).State = EntityState.Unchanged;
                    await((DbContext)_dbContext).SaveChangesAsync();

                    tranaction.Commit();
                    
                    return _mapper.Map<DbTicket, Ticket>(dbTicket);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null!;
        }
    }
}
