using YourTurnFriend.Domain.Entities.Event;
using Entity = YourTurnFriend.Domain.Entities.Event.Event;

namespace YourTurnFriend.Application.Features.V1.Event.Responses;

public record EventResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string IdOwner { get; set; }
    public DateTime DateOfNextEvent { get; set; }
    public DateTime? DateOfLastEvent { get; set; }
    public int DaysToNextEvent { get; set; }
    public string Frequence { get; set; } = string.Empty;
    public string? IdOfNextMemberInTurn { get;  set; }
    public IEnumerable<MemberResponse> Members { get; set;} = [];

    private EventResponse
    (
        string id,
        string title,
        string idOwner,
        DateTime dateOfNextEvent,
        DateTime? dateOfLastEvent,
        int daysToNextEvent,
        string frequence,
        string? idOfNextMemberInTurn,
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
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IdEvent { get; set; }

    public MemberResponse()
    { }

    private MemberResponse
    (
        string id,
        string name,
        string idEvent
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