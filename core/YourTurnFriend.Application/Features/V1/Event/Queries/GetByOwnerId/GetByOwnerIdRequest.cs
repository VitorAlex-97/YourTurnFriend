using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

public record GetByOwnerIdRequest
(
    Guid OwnerId
) : IRequest<Response<EventResponse>>;