using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Data;

namespace GloboTicket.TicketManagement.Persistence.Repositories;

public class Eventrepository : BaseRepository<Event>, IEventRepository
{
    public Eventrepository(GloboTicketDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
        return Task.FromResult(matches);
    }
}
