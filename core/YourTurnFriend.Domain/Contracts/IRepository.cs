using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Contracts;

public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
{ }