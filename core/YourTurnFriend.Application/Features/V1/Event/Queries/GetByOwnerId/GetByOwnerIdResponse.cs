namespace YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

public record GetByOwnerIdResponse
(
    Guid Id,
    Guid IdOwner,
    string Frequence,
    int DaysToNextEvent,
    DateTime? DateOfLastEvent,
    Guid? IdOfNextMemberInTurn,
    IEnumerable<MemberResponse> Members
);

public record MemberResponse
(
    Guid Id,
    string Name
);