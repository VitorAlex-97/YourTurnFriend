using YourTurnFriend.Domain.Entities.User;

namespace YourTurnFriend.Domain.DomainServices.Interfaces;

public interface IAddRoleToUserService : IDomainService
{
    Task<User> ExecuteAsync(User userToReciveRoles, List<string> rolesNames, CancellationToken cancellationToken = default);
}