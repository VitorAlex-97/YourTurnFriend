using System.Security.Cryptography;
using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.User;

public class User : AggregateRoot
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? LastUpdatedAt { get; private set; }

    protected User()
    {}

    public User
    (
        string userName,
        string password
    )
    {
        Username = userName;
        CreatedAt = DateTime.Now;
        Password = password;
        Validate();
    }

    protected override void Validate()
    {
        DomainStringValidations.MaxLength(50, Username, nameof(Username));
        DomainStringValidations.MinLength(3, Username, nameof(Username));

        DomainStringValidations.MaxLength(8, Password, nameof(Password));
    }
}