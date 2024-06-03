using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public sealed class Member : Entity
{

    public string Name { get; }
    public Guid EventId { get; }
    public int? SequenceInEvent { get; private set; }

    private Member()
    { }

    public Member
    (
        string name,
        Guid idEvent
    ) : base()
    {
        Name = name;
        EventId = idEvent;

        Validate();
    }

    protected override void Validate()
    {
        DomainStringValidations.MinLength(3, Name, nameof(Name));
        DomainStringValidations.MaxLength(20, Name, nameof(Name));
        DomainExceptionValidation.When(SequenceInEvent is not null && 
                                        SequenceInEvent <= 0,
                                        $"{nameof(SequenceInEvent)} must be greater than 0."
                                    );
    }

    internal void UpdateSequence(int sequenceInEvent)
    {
        SequenceInEvent = sequenceInEvent;

        Validate();
    }
}