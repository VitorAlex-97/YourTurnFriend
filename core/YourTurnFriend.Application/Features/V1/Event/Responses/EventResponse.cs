using YourTurnFriend.Domain.Entities.Event;
using Entity = YourTurnFriend.Domain.Entities.Event.Event;

namespace YourTurnFriend.Application.Features.V1.Event.Responses;

public record EventResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid IdOwner { get; set; }
    public DateTime DateOfNextEvent { get; set; }
    public DateTime? DateOfLastEvent { get; set; }
    public int DaysToNextEvent { get; set; }
    public string Frequence { get; set; } = string.Empty;
    public Guid? IdOfNextMemberInTurn { get;  set; }
    public IEnumerable<MemberResponse> Members { get; set;} = [];

    private EventResponse
    (
        Guid id,
        string title,
        Guid idOwner,
        DateTime dateOfNextEvent,
        DateTime? dateOfLastEvent,
        int daysToNextEvent,
        string frequence,
        Guid? idOfNextMemberInTurn,
        IEnumerable<MemberResponse> members
    )
    {
        Id = id;
        Title = title;
        IdOwner = idOwner;
        DateOfNextEvent = dateOfNextEvent;
        DateOfLastEvent = dateOfLastEvent;
        DaysToNextEvent = daysToNextEvent;
        Frequence = frequence;
        IdOfNextMemberInTurn = idOfNextMemberInTurn;
        Members = members;
    }

    public static EventResponse FromEntity(Entity eventEntity)
    {
        return new EventResponse(
                    id: eventEntity.Id,
                    title: eventEntity.Title,
                    idOwner: eventEntity.IdOwner,
                    dateOfNextEvent: eventEntity.DateOfNextEvent,
                    dateOfLastEvent: eventEntity.DateOfLastEvent,
                    daysToNextEvent: eventEntity.DaysToNextEvent,
                    frequence: eventEntity.Frequence.ToString(),
                    idOfNextMemberInTurn: eventEntity.IdOfNextMemberInTurn,
                    members: eventEntity.Members.Select(MemberResponse.FromEntity)
                );
    }
}

public record MemberResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid IdEvent { get; set; }

    public MemberResponse()
    { }

    private MemberResponse
    (
        Guid id,
        string name,
        Guid idEvent
    )
    {
        Id = id;
        Name = name;
        IdEvent = idEvent;
    }

    public static MemberResponse FromEntity(Member member)
    {
        return new MemberResponse(
                    id: member.Id,
                    name: member.Name,
                    idEvent: member.IdEvent
                );
    }
}