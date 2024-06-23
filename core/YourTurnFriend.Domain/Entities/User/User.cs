using YourTurnFriend.Domain.DomainEvents.User;
using RoleAggregate = YourTurnFriend.Domain.Entities.Role;
using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.User;

public class User : AggregateRoot
{
    private readonly HashSet<RoleAggregate.Role> _roles;

    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? LastUpdatedAt { get; private set; }
    public IReadOnlySet<RoleAggregate.Role> Roles => _roles;

    protected User()
    {}

    private User
    (
        string username,
        string password
    )
    {
        Username = username;
        CreatedAt = DateTime.Now;
        Password = password;
        Validate();
    }

    public static User Create
    (
        string username,
        string password
    )
    {
        var user = new User(username, password);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public static void ValidateFormatePassword(string password)
    {
        DomainStringValidations.MinLength(8, password, nameof(Password));
    }

    internal void AddRole(RoleAggregate.Role role) 
    {
        var wasAdd = _roles.Add(role);

        if (wasAdd)
        {
            RaiseDomainEvent(new UserReciveANewRole(Id, role.Id));
        }
    }

    protected override void Validate()
    {
        DomainStringValidations.MaxLength(50, Username, nameof(Username));
        DomainStringValidations.MinLength(3, Username, nameof(Username));
        DomainStringValidations.NotNull(Password, nameof(Password));
    }
}