using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.RemoveMember;

public record RemoveMemberCommand(Guid EventId, Guid MemberId)
    : IRequest<Response<EventResponse>>;