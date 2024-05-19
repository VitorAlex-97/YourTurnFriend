namespace YourTurnFriend.Domain.Contracts.Persistence;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}