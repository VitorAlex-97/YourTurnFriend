using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;
using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.GenerateNextEventDate;

public class GenerateNextEventDateHandler
(
    IUnitOfWork unitOfWork, 
    IEventRepository eventRepository
)
: IRequestHandler<GenerateNextEventDateRequest, Response<EventResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<EventResponse>> Handle
    (
        GenerateNextEventDateRequest request, 
        CancellationToken cancellationToken
    )
    {
        var eventInProcess = await _eventRepository.GetByIdAsync(
                                        id: request.EventId,
                                        cancellationToken: cancellationToken,
                                        includes: eventDb => eventDb.Members
                                    )
                                ?? throw new BusinessException("Event does not exists.");

        eventInProcess.GenerateNextEventDate();

        await _unitOfWork.CommitAsync(cancellationToken);

        return Response<EventResponse>.Success(EventResponse.FromEntity(eventInProcess));
    }
}
