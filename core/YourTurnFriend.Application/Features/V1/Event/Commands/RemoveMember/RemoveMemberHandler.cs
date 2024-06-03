using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;
using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.RemoveMember;

public class RemoveMemberHandler
(
    IEventRepository eventRepository, 
    IUnitOfWork unitOfWork
) : IRequestHandler<RemoveMemberCommand, Response<EventResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<EventResponse>> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
    {
        var eventDb = await _eventRepository.GetByIdAsync(
                                id: request.EventId,
                                cancellationToken: cancellationToken,
                                includes:e => e.Members
                            ) ?? throw new BusinessException("Event not found.");

        eventDb.RemoveMember(request.MemberId);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Response<EventResponse>.Success(EventResponse.FromEntity(eventDb));
    }
}