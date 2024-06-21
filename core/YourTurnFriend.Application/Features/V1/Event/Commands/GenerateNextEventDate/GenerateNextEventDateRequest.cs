using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.GenerateNextEventDate;

public record GenerateNextEventDateRequest
(
    Guid EventId, 
    bool FromToDay = false
) : IRequest<Response<EventResponse>>;