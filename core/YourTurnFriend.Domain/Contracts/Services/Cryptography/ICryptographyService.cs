namespace YourTurnFriend.Domain.Contracts.Services.Cryptography;

public interface ICryptographyService
{
    Task<string> Encrypt(string source, CancellationToken cancellationToken = default);
    Task<bool> Compare(string source, string target, CancellationToken cancellationToken = default);
}