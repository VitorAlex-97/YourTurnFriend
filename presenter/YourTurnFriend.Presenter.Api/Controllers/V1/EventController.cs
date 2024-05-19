using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Commands.AddMembers;
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

    [HttpPut("{id}/AddMembers")]
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


    [HttpGet]
    public async Task<ActionResult<Response<CreateEventResponse>>> Get
    (
    ) 
    {

        return Ok("Pegou");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<EventResponse>>> GetById
    ([FromRoute] Guid id) 
    {
        var request = new GetByOwnerIdRequest(id);

        var response = await _mediator.Send(request);
        
        return Ok(response);
    }
}