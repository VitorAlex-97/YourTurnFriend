using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

internal class UserRepository(ApplicationDbContext context) 
    : BaseReadRepository<User>(context), IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(User aggregateRoot, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(aggregateRoot, cancellationToken);
    }

    public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AnyAsync(user => user.Username == username, cancellationToken);
    }

    public async Task<User?> GetOneAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Username == username, cancellationToken);
    }
}