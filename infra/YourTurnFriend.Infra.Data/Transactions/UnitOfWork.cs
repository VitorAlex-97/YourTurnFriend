using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Transactions;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}