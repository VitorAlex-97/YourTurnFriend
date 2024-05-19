using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts.Persistence;

public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
{ }