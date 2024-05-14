using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourTurnFriend.Domain.Entities.Event;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

internal class EventRepository(ApplicationDbContext context) : IEventRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Event aggregateRoot, CancellationToken cancellationToken = default)
    {
        await _context.Set<Event>().AddAsync(aggregateRoot, cancellationToken);
    }
}