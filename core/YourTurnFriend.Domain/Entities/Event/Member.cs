using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public class Member : Entity
{

    public string Name { get; private set; }
    public string IdEvent { get; private set; }

    protected Member()
    { }

    public Member
    (
        string name,
        string idEvent
    ) : base()
    {
        Name = name;
        IdEvent = idEvent.ToString();

        Validate();
    }

    protected override void Validate()
    {
        DomainStringValidations.MinLength(3, Name, nameof(Name));
        DomainStringValidations.MaxLength(20, Name, nameof(Name));
    }
}