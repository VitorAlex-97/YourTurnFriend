using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.Entities.Event;

namespace YourTurnFriend.Domain.Repositories;

public interface IEventRepository : IRepository<Event>, IWriteRepository<Event>
{ }
