using MediatR;
using YourTurnFriend.Application.Commons.Constants;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Contracts;
using YourTurnFriend.Domain.Enums.Event;
using YourTurnFriend.Domain.Repositories;
using EventAggregate = YourTurnFriend.Domain.Entities.Event.Event;

namespace YourTurnFriend.Application.Features.V1.Event.Commnands.CreateEvent;
public class CreateEventHandler
(
    IEventRepository eventRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateEventRequest, Response<CreateEventResponse>>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<CreateEventResponse>> Handle
    (
        CreateEventRequest request, 
        CancellationToken cancellationToken
    )
    {
        //var user = await _userRepository.GetByIdAsync(request.IdOwner, cancellationToken);

        var isEFrequenceEnum = Enum.TryParse<EFrequenceOfEvent>
                                    (
                                        request.FrequenceOfEvent, 
                                        true, 
                                        out var frequenceOfEvent
                                    );

        if (!isEFrequenceEnum)
        {
            throw new BusinessException("Invalid Frequence.");
        }

        // if (user is null)
        // {
        //     throw new ApplicationException("User does not exists.");
        // }

        var newEvent = new EventAggregate(
                                title: request.Title,
                                frequenceOfEvent: frequenceOfEvent, 
                                idOwner: request.IdOwner
                            );

        await _eventRepository.AddAsync(
                    aggregateRoot: newEvent, 
                    cancellationToken: cancellationToken
                );

        await _unitOfWork.CommitAsync(cancellationToken);

        var responseData = new CreateEventResponse(newEvent.Id);

        return Response<CreateEventResponse>.Success(responseData);
    }
}
