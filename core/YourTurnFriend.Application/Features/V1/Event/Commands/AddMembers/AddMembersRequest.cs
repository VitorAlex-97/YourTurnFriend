using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.AddMembers;

public record AddMembersRequest
(
    Guid IdEvent,
    IEnumerable<string> Names
) : IRequest<Response<EventResponse>>;