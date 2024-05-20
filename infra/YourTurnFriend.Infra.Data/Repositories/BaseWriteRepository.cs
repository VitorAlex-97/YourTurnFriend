using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories
{
}
public class BaseWriteRepository<TAggregateRoot>(ApplicationDbContext context)
    : IWriteRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default)
    {
        await _context.Set<TAggregateRoot>()
                    .AddAsync(aggregateRoot, cancellationToken);
    }
}