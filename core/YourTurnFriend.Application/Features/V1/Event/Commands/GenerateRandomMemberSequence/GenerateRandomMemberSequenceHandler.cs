using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;
using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.GenerateRandomMemberSequence;

public class GenerateRandomMemberSequenceHandler
(
    IEventRepository eventRepository, 
    IUnitOfWork unitOfWork
)
    : IRequestHandler<GenerateRandomMemberSequenceRequest, Response<EventResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<EventResponse>> Handle
    (
        GenerateRandomMemberSequenceRequest request, 
        CancellationToken cancellationToken
    )
    {
        var eventDb = await _eventRepository.GetByIdAsync(
                                id: request.EventId,
                                cancellationToken: cancellationToken,
                                eventDb => eventDb.Members
                            )
                        ?? throw new BusinessException("User does not exists.");

        eventDb.GenerateRandomMemberSequenceTurn();

        await _unitOfWork.CommitAsync(cancellationToken);

        return Response<EventResponse>.Success(EventResponse.FromEntity(eventDb));
    }
}