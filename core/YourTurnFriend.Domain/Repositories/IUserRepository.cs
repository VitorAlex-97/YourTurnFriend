using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Entities.User;

namespace YourTurnFriend.Domain.Repositories;

public interface IUserRepository : IReadRepository<User>, IWriteRepository<User>
{ 
    Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
}
