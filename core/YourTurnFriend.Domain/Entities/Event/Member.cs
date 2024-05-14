using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public class Member : Entity
{

    public string Name { get; private set; }
    public Guid IdEvent { get; private set; }

    public Member
    (
        string name,
        Guid idEvent
    ) : base()
    {
        Name = name;
        IdEvent = idEvent;

        Validate();
    }

    protected override void Validate()
    {
        DomainStringValidations.MinLength(3, Name, nameof(Name));
        DomainStringValidations.MaxLength(20, Name, nameof(Name));
    }
}