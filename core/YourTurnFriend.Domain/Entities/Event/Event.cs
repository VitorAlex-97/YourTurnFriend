using YourTurnFriend.Domain.Enums.Event;
using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public sealed class Event : AggregateRoot
{
    private readonly HashSet<Member> _members = [];

    public string Title { get; private set; }
    public Guid IdOwner { get; }
    public DateTime? DateOfLastEvent { get; private set; }
    public int DaysToNextEvent => CalcuteDaysToNextEvent();
    public EFrequenceOfEvent Frequence { get; private set; }
    public Guid? IdOfNextMemberInTurn { get; private set; }
    public IReadOnlySet<Member> Members => _members;

    public Event
    (
        string title,
        EFrequenceOfEvent frequenceOfEvent,
        Guid idOwner
    ) : base()
    {
        IdOwner = idOwner;
        Title = title;
        Frequence = frequenceOfEvent;

        Validate();
    }

    public void AddMember(string name) 
    {
        var alreadyExistsMemberWithSameName = _members.Any(member => member.Name == name);

        DomainExceptionValidation.When(alreadyExistsMemberWithSameName, $"Already a member with {name}");

        var newMember = new Member(name, Id);

        _members.Add(newMember);
    }

    public void RemoveMember(Guid idMember)
    {
       var result = _members.RemoveWhere((member) => member.Id == idMember);

        DomainExceptionValidation.When(result == decimal.Zero, "Member does not exists");
    }

    public void GenerateRandomMemberSequenceTurn() 
    {
        var random = new Random().Next(_members.Count, 0);

        var memberInitialEvent = _members.ToArray()[random];

        IdOfNextMemberInTurn = memberInitialEvent.Id;
    }

    private int CalcuteDaysToNextEvent()
    {
        var quantityDaysFromFrequence = QuantittyDaysFromFrequence();

        if (DateOfLastEvent is null) return 0;

        var daysToNextEvent = (DateOfLastEvent?.AddDays(quantityDaysFromFrequence) - DateTime.Now)?.Days;

        return daysToNextEvent ?? 0;
    }

    private int QuantittyDaysFromFrequence()
    {
        return Frequence switch
        {
            EFrequenceOfEvent.WEEK => 7,
            EFrequenceOfEvent.BIWEEK => 14,
            EFrequenceOfEvent.MONTH => 30,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    protected override void Validate()
    {
        DomainStringValidations.MinLength(3,Title, nameof(Title));
        DomainStringValidations.MaxLength(50,Title, nameof(Title));
        DomainExceptionValidation.When(IdOwner.Equals(default), $"{IdOwner} must have a value");
    }
}
