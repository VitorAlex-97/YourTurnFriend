using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

public class BaseReadRepository<TAggragateRoot>(ApplicationDbContext context) 
    : IReadRepository<TAggragateRoot> 
        where TAggragateRoot : AggregateRoot
{
    private readonly ApplicationDbContext _context = context;

    public Task<TAggragateRoot?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Set<TAggragateRoot>()
                    .FirstOrDefaultAsync(
                        aggregate => aggregate.Id.ToString() == id.ToString(), 
                        cancellationToken
                    );
    }
}