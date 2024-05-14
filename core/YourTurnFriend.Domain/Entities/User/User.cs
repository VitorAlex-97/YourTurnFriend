using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.User;

public class User : AggregateRoot
{
    public string UserName { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? LastUpdatedAt { get; private set; }

    public User
    (
        string userName
    )
    {
        UserName = userName;
        CreatedAt = DateTime.Now;

        Validate();
    }

    protected override void Validate()
    {
        DomainStringValidations.MinLength(3, UserName, nameof(UserName));
        DomainStringValidations.MaxLength(50, UserName, nameof(UserName));
    }
}