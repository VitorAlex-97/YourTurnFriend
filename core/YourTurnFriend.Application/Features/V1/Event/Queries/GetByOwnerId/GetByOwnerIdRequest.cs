using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;

namespace YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

public record GetByOwnerIdRequest
(
    Guid OwnerId
) : IRequest<Response<GetByOwnerIdResponse>>;