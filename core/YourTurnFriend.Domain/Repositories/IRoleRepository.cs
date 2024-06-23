using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Entities.Role;

namespace YourTurnFriend.Domain.Repositories;

public interface IRoleRepository : IReadRepository<Role>
{
    Task<Role?> GetOneAsync(string name, CancellationToken cancellationToken = default);
    Task<HashSet<Role>> GetAllAsync(List<string> names, CancellationToken cancellationToken = default);
}