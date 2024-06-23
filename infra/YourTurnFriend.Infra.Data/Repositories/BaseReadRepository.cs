using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

public class BaseReadRepository<TAggregateRoot>(ApplicationDbContext context) 
    : IReadRepository<TAggregateRoot> 
        where TAggregateRoot : AggregateRoot
{
    private readonly ApplicationDbContext _context = context;

    public async Task<TAggregateRoot?> GetOneAsync(
        Guid id, 
        bool asTracking = false,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Set<TAggregateRoot>()
                            .AsQueryable();

        if (asTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(
                        aggregate => aggregate.Id.ToString() == id.ToString(), 
                        cancellationToken
                    );
    }
}