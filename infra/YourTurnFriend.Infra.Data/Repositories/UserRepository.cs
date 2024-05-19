using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

internal class UserRepository(ApplicationDbContext context) 
    : BaseReadRepository<User>(context), IUserRepository
{
    private readonly ApplicationDbContext _context = context;
}