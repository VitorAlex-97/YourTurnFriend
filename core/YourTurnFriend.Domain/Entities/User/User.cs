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
        string username,
        string password
    )
    {
        Username = username;
        CreatedAt = DateTime.Now;
        Password = password;
        Validate();
    }

    public static void ValidateFormatePassword(string password)
    {
        DomainStringValidations.MinLength(8, password, nameof(Password));
    }

    protected override void Validate()
    {
        DomainStringValidations.MaxLength(50, Username, nameof(Username));
        DomainStringValidations.MinLength(3, Username, nameof(Username));
    }
}