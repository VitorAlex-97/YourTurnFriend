using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.GenerateRandomMemberSequence;

public record GenerateRandomMemberSequenceRequest
(
    Guid EventId
) : IRequest<Response<EventResponse>>;