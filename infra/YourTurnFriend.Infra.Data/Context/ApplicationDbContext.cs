using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YourTurnFriend.Domain.Entities.Event;
using YourTurnFriend.Domain.Entities.Role;
using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Infra.Data.OutBox;

namespace YourTurnFriend.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<OutBoxMessage> OutBoxMessages { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}