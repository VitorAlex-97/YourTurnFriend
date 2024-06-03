using YourTurnFriend.Domain.Enums.Event;
using YourTurnFriend.Domain.Exceptions;
using YourTurnFriend.Domain.SeedWorks;

namespace YourTurnFriend.Domain.Entities.Event;

public sealed class Event : AggregateRoot
{
    private readonly HashSet<Member> _members = [];

    public string Title { get; private set; }
    public Guid OwnerId { get; }
    public DateTime DateOfNextEvent { get; private set; }
    public DateTime? DateOfLastEvent { get; private set; }
    public int DaysToNextEvent => CalcuteDaysToNextEvent();
    public EFrequenceOfEvent Frequence { get; private set; }
    public Guid? IdOfNextMemberInTurn { get; private set; }
    public IReadOnlySet<Member> Members => _members;

    protected Event()
    { }

    public Event
    (
        string title,
        EFrequenceOfEvent frequenceOfEvent,
        Guid idOwner,
        DateTime dateOfNextEvent
    ) : base()
    {
        OwnerId = idOwner;
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

        if (IdOfNextMemberInTurn is not null)
        {
            GenerateRandomMemberSequenceTurn();
        }

        Validate();
    }

    public void RemoveMember(Guid memberId)
    {
        var result = _members.RemoveWhere((member) => member.Id == memberId);

        DomainExceptionValidation.When(result == decimal.Zero, "Member does not exists");

        if (IdOfNextMemberInTurn is not null)
        {
            GenerateRandomMemberSequenceTurn();
        }

        Validate();
    }

    public void GenerateRandomMemberSequenceTurn() 
    {
        DomainExceptionValidation.When(_members.Count == 0, 
                                        $"To generate random member sequence, should be {nameof(Members)} in Event");

        var membersForOperationArray = _members.ToArray();

        var quantityOfMembers = membersForOperationArray.Length;
        var sequences = Enumerable.Range(1, quantityOfMembers).ToList();

        var random = new Random();
        for (var index = quantityOfMembers - 1; index > 0; index--)
        {
            var randomPosition = random.Next(index + 1);
            (sequences[randomPosition], sequences[index]) = (sequences[index], sequences[randomPosition]);
        }

        for (var index = 0; index < quantityOfMembers; index++)
        {
            membersForOperationArray[index].UpdateSequence(sequences[index]);
        }

        var idOfNextMemberInTurn = _members.Where(x => x.SequenceInEvent == 1)
                                            .Select(x => x.Id)
                                            .FirstOrDefault();

        DomainExceptionValidation.When(idOfNextMemberInTurn == default, 
                                        "Not possible set the next friend turn.");                    
        
        IdOfNextMemberInTurn = idOfNextMemberInTurn;

        Validate();
    }

    private int CalcuteDaysToNextEvent()
    {
        return (DateOfNextEvent.Date - DateTime.Now.Date).Days;
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
                                        $"{nameof(DateOfNextEvent)} must have a value.");

        DomainExceptionValidation.When(DateOfNextEvent.Date < DateTime.Now,
                                        $"{nameof(DateOfNextEvent)} must have a greater than today.");
                                       
        DomainExceptionValidation.When(OwnerId.Equals(default), $"{OwnerId} must have a value.");

        DomainExceptionValidation.When(IdOfNextMemberInTurn != null &&
                                        _members.Count == 0,
                                        $"When Even there is no members, then {IdOfNextMemberInTurn} must have no value.");
    }
}
