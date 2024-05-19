using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Responses;
using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.Event.Commands.AddMembers;

public class AddMembersHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<AddMembersRequest, Response<EventResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<EventResponse>> Handle(AddMembersRequest request, CancellationToken cancellationToken)
    {
        var eventDb = await _eventRepository.GetByIdAsync(
                                id: request.IdEvent,
                                wantPersistence: true,
                                cancellationToken: cancellationToken,
                                includes: eventDb => eventDb.Members
                            )
                        ?? throw new BusinessException("User does not exists.");

        Parallel.ForEach(request.Names, eventDb.AddMember);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Response<EventResponse>.Success(EventResponse.FromEntity(eventDb));
    }
}