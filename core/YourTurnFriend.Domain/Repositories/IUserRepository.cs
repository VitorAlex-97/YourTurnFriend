using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.Entities.User;

namespace YourTurnFriend.Domain.Repositories;

public interface IUserRepository : IRepository<User>, IReadRepository<User>
{ }
