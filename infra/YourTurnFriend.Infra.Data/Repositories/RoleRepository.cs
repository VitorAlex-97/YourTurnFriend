using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Entities.Role;
using YourTurnFriend.Domain.Repositories;
using YourTurnFriend.Infra.Data.Context;

namespace YourTurnFriend.Infra.Data.Repositories;

public class RoleRepository(ApplicationDbContext context) 
    : BaseReadRepository<Role>(context), IRoleRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<HashSet<Role>> GetAllAsync(List<string> names, CancellationToken cancellationToken = default)
    {
        var roles = await _context.Roles.Where(role => names.Contains(role.Name))
                                    .ToListAsync(cancellationToken);

        return [.. roles];
    }

    public async Task<Role?> GetOneAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Roles.FirstOrDefaultAsync(role => role.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase), cancellationToken);
    }
}