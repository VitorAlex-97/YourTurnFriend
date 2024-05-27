using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;

namespace YourTurnFriend.Application.Features.V1.Event.Commnands.CreateEvent;

public class CreateEventRequest : IRequest<Response<CreateEventResponse>>
{
    public Guid IdOwner { get; set; }
    public string Title { get; set; } = string.Empty;
    public string FrequenceOfEvent { get; set; } = string.Empty;
    public string? DateOfNextEvent { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();
}