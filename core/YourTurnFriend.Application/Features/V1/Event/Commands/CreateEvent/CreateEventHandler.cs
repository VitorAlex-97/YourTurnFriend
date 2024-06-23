using System.Globalization;
using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Contracts.Persistence;
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
        var user = await _userRepository.GetOneAsync(
                            id: request.IdOwner, 
                            cancellationToken: cancellationToken
                        )
                    ?? throw new BusinessException("User does not exists.");

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
        
        DateTime.TryParseExact(
            s: request.DateOfNextEvent, 
            format: "dd/MM/yyyy", 
            provider: CultureInfo.InvariantCulture, 
            style: DateTimeStyles.None, 
            result: out DateTime dateOfNextEvent
        );
        
        var newEvent = EventAggregate.Create(
                                title: request.Title,
                                frequenceOfEvent: frequenceOfEvent, 
                                ownerId: user.Id,
                                dateOfNextEvent: dateOfNextEvent,
                                namesOfMembers: request.NamesOfMembers
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
