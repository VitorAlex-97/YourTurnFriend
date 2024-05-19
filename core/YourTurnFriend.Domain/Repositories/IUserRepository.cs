using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Entities.User;

namespace YourTurnFriend.Domain.Repositories;

public interface IUserRepository : IRepository<User>, IReadRepository<User>
{ }
