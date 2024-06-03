using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Commands.AddMembers;
using YourTurnFriend.Application.Features.V1.Event.Commands.GenerateRandomMemberSequence;
using YourTurnFriend.Application.Features.V1.Event.Commands.RemoveMember;
using YourTurnFriend.Application.Features.V1.Event.Commnands.CreateEvent;
using YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;
using YourTurnFriend.Application.Features.V1.Event.Responses;

namespace YourTurnFriend.Presenter.Api.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class EventController(IMediator mediator) : ControllerBase
{
   private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<Response<CreateEventResponse>>> CreateEvent
    (
        [FromBody] CreateEventRequest request
    ) 
    {
        var response = await _mediator.Send(request);

        return CreatedAtAction(nameof(CreateEvent), response);
    }

    [HttpPost("{id}/AddMembers")]
    public async Task<ActionResult<Response<EventResponse>>> AddMembers
    (
        [FromRoute] Guid id,
        [FromBody] List<string> names
    ) 
    {
        var request = new AddMembersRequest(id, names);

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPatch("{id}/GenerateRandomMemberSequence")]
    public async Task<ActionResult<Response<EventResponse>>> GenerateRandomMemberSequence
    (
        [FromRoute] Guid id
    ) 
    {
        var request = new GenerateRandomMemberSequenceRequest(id);

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<EventResponse>>> GetById
    ([FromRoute] Guid id) 
    {
        var request = new GetByOwnerIdRequest(id);

        var response = await _mediator.Send(request);
        
        return Ok(response);
    }

    [HttpDelete("{id}/RemoveMember/{memberId}")]
    public async Task<ActionResult<Response<EventResponse>>> GetById
    (
        [FromRoute] Guid id, 
        [FromRoute] Guid memberId
    ) 
    {
        var request = new RemoveMemberCommand(id, memberId);

        var response = await _mediator.Send(request);
        
        return Ok(response);
    }
}