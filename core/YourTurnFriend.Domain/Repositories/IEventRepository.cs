using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Entities.Event;

namespace YourTurnFriend.Domain.Repositories;

public interface IEventRepository : IWriteRepository<Event>, IReadRepository<Event>
{ }
