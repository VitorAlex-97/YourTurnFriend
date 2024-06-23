using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Role;

public sealed class Role : AggregateRoot
{
    public string Name { get; }
    public DateTime CreatedAt { get; }

    private Role(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;     
    }
    public static Role Create(string name)
    {
        var newRole = new Role(name);

        return newRole;
    }
    protected override void Validate()
    {
        DomainStringValidations.NotNull(Name, nameof(Name));
        DomainStringValidations.MinLength(3, Name, nameof(Name));
    }
}