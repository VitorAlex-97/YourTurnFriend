using System.Linq.Expressions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts;

public interface IReadRepository<TAggregateRoot> 
    : IRepository<TAggregateRoot> 
        where TAggregateRoot : AggregateRoot
{
    Task<TAggregateRoot?> GetByIdAsync(
        Guid id, 
        bool wantPersistence = false,
        CancellationToken cancellationToken = default,
        params Expression<Func<TAggregateRoot, object>>[] includes);
}