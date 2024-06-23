using MediatR;
using YourTurnFriend.Application.Commons.Constants;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

public class GetByOwnerIdHandler : IRequestHandler<GetByOwnerIdRequest, Response<EventResponse>>
{
    private readonly IEventRepository _eventRepository;

    public GetByOwnerIdHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Response<EventResponse>> Handle(GetByOwnerIdRequest request, CancellationToken cancellationToken)
    {
        var eventDb = await _eventRepository.GetOneAsync(
                                id: request.OwnerId, 
                                cancellationToken: cancellationToken
                            ) 
                        ?? throw new BusinessException("Event does not exists.", ApiStatusCode.NOT_FOUND);
                        
        return Response<EventResponse>.Success(EventResponse.FromEntity(eventDb));
    }
}