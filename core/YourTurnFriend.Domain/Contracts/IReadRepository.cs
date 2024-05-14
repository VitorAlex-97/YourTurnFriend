using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts;

public interface IReadRepository<TAggragateRoot> 
    : IRepository<TAggragateRoot> 
        where TAggragateRoot : AggregateRoot
{
    Task<TAggragateRoot?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}