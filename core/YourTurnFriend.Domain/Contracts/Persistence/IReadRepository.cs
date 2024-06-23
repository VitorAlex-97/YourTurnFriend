using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts.Persistence;

public interface IReadRepository<TAggregateRoot> 
    : IRepository<TAggregateRoot> 
        where TAggregateRoot : AggregateRoot
{
    Task<TAggregateRoot?> GetOneAsync(
        Guid id, 
        bool asTracking = false,
        CancellationToken cancellationToken = default
    );
}