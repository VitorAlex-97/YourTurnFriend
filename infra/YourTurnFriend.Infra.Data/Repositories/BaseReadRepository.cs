using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.SeedWorks;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

public class BaseReadRepository<TAggregateRoot>(ApplicationDbContext context) 
    : IReadRepository<TAggregateRoot> 
        where TAggregateRoot : AggregateRoot
{
    private readonly ApplicationDbContext _context = context;

    public async Task<TAggregateRoot?> GetByIdAsync(
        Guid id, 
        bool wantPersistence = false,
        CancellationToken cancellationToken = default,
        params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = _context.Set<TAggregateRoot>()
                            .AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (!wantPersistence)
        {
            query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(
                        aggregate => aggregate.Id.ToString() == id.ToString(), 
                        cancellationToken
                    );
    }
}