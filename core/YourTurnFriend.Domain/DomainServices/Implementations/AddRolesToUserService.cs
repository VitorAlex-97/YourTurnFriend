using YourTurnFriend.Domain.DomainServices.Interfaces;
using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Domain.DomainServices.Implementations;

public sealed class AddRolesToUserService(IRoleRepository roleRepository) 
    : IAddRoleToUserService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<User> ExecuteAsync(
        User userToReciveNewRoles, 
        List<string> namesOfRoles, 
        CancellationToken cancellationToken = default
    )
    {
        var roles = await _roleRepository.GetAllAsync(
                                names: namesOfRoles, 
                                cancellationToken: cancellationToken
                            );

        var rolesToAddToUser = roles.Where(role => !userToReciveNewRoles.Roles.Contains(role));

        Parallel.ForEach(rolesToAddToUser, userToReciveNewRoles.AddRole);

        return userToReciveNewRoles;
    }
}