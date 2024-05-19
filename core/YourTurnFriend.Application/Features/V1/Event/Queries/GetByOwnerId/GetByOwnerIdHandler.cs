using MediatR;
using YourTurnFriend.Application.Commons.Constants;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

public class GetByOwnerIdHandler : IRequestHandler<GetByOwnerIdRequest, Response<GetByOwnerIdResponse>>
{
    private readonly IEventRepository _eventRepository;

    public GetByOwnerIdHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Response<GetByOwnerIdResponse>> Handle(GetByOwnerIdRequest request, CancellationToken cancellationToken)
    {
        var eventDb = await _eventRepository.GetByIdAsync(
                                request.OwnerId, 
                                cancellationToken,
                                eventDb => eventDb.Members
                            ) 
                        ?? throw new BusinessException("Event does not exists.", ApiStatusCode.NOT_FOUND);
                        
        return Response<GetByOwnerIdResponse>.Success(new GetByOwnerIdResponse(
                                                            eventDb.Id,
                                                            eventDb.IdOwner,
                                                            eventDb.Frequence.ToString(),
                                                            eventDb.DateOfNextEvent,
                                                            eventDb.DaysToNextEvent,
                                                            eventDb.DateOfLastEvent,
                                                            eventDb.IdOfNextMemberInTurn,
                                                            eventDb.Members.Select(
                                                                m => new MemberResponse(
                                                                    m.Id,
                                                                    m.Name
                                                                )
                                                            )
                                                        )
                                                    );
    }
}