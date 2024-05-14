using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts;

public interface IWriteRepository<TAggregateRoot> 
    : IRepository<TAggregateRoot> 
        where TAggregateRoot : AggregateRoot
{
    Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default);
}