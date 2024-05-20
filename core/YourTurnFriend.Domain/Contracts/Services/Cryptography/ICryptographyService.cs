namespace YourTurnFriend.Domain.Contracts.Services.Cryptography;

public interface ICryptographyService
{
    Task<string> EncryptAsync(string source, CancellationToken cancellationToken = default);
    Task<bool> CompareAsync(string source, string target, CancellationToken cancellationToken = default);
}