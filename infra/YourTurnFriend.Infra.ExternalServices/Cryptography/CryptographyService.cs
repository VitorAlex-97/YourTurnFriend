using YourTurnFriend.Domain.Contracts.Services.Cryptography;

namespace YourTurnFriend.Infra.ExternalServices.Cryptography;

internal class CryptographyService : ICryptographyService
{
    public async Task<bool> CompareAsync(string source, string target, CancellationToken cancellationToken = default)
    {
        var verifiedPassword = await Task.FromResult(BCrypt.Net.BCrypt.Verify(source, target));

        return verifiedPassword;
    }

    public async Task<string> EncryptAsync(string source, CancellationToken cancellationToken = default)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();

        var hashedPassword = await Task.FromResult(BCrypt.Net.BCrypt.HashPassword(source, salt));

        return hashedPassword;
    }
}