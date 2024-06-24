using YourTurnFriend.Domain.Entities.User;

namespace YourTurnFriend.Domain.Contracts.Services.Security;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user, CancellationToken cancellationToken = default);
}