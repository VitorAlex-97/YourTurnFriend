using YourTurnFriend.Domain.Entities.Event;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

internal class EventRepository(ApplicationDbContext context) 
    : BaseReadRepository<Event>(context), IEventRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Event aggregateRoot, CancellationToken cancellationToken = default)
    {
        await _context.Events.AddAsync(aggregateRoot, cancellationToken);
    }
}