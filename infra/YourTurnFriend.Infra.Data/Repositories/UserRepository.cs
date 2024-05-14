using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

internal class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken: cancellationToken);
    }
}