using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;

namespace YourTurnFriend.Application.Features.V1.Event.Commnands.CreateEvent;

public class CreateEventRequest : IRequest<Response<CreateEventResponse>>
{
    public Guid IdOwner { get; }
    public string Title { get; } = string.Empty;
    public string FrequenceOfEvent { get; } = string.Empty;
}