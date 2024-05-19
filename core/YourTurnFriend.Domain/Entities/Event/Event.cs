using YourTurnFriend.Domain.Enums.Event;
using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public sealed class Event : AggregateRoot
{
    private readonly HashSet<Member> _members = [];

    public string Title { get; private set; }
    public string IdOwner { get; }
    public DateTime DateOfNextEvent { get; private set; }
    public DateTime? DateOfLastEvent { get; private set; }
    public int DaysToNextEvent => CalcuteDaysToNextEvent();
    public EFrequenceOfEvent Frequence { get; private set; }
    public string? IdOfNextMemberInTurn { get; private set; }
    public IReadOnlySet<Member> Members => _members;

    protected Event()
    { }
    public Event
    (
        string title,
        EFrequenceOfEvent frequenceOfEvent,
        string idOwner,
        DateTime dateOfNextEvent
    ) : base()
    {
        IdOwner = idOwner;
        Title = title;
        Frequence = frequenceOfEvent;
        DateOfNextEvent = dateOfNextEvent;

        Validate();
    }

    public void AddMember(string name) 
    {
        var alreadyExistsMemberWithSameName = _members.Any(member => member.Name == name);

        DomainExceptionValidation.When(alreadyExistsMemberWithSameName, $"Already a member with {name}");

        var newMember = new Member(name, Id);

        _members.Add(newMember);
    }

    public void RemoveMember(string idMember)
    {
       var result = _members.RemoveWhere((member) => member.Id == idMember.ToString());

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
        return (DateOfNextEvent - DateTime.Now).Days;
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

        DomainExceptionValidation.When(DateOfNextEvent == default,
                                        $"{nameof(DateOfNextEvent)} must have a value");

        DomainExceptionValidation.When(DateOfNextEvent.Date < DateTime.Now,
                                        $"{nameof(DateOfNextEvent)} must have a greater than today");
                                       
        DomainExceptionValidation.When(IdOwner.Equals(default), $"{IdOwner} must have a value");
    }
}
