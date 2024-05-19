using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.Event.Commnands.CreateEvent;
using YourTurnFriend.Application.Features.V1.Event.Queries.GetByOwnerId;

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

    [HttpGet]
    public async Task<ActionResult<Response<CreateEventResponse>>> Get
    (
    ) 
    {

        return Ok("Pegou");
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<GetByOwnerIdResponse>>> GetById
    ([FromRoute] Guid id) 
    {
        var request = new GetByOwnerIdRequest(id);

        var response = await _mediator.Send(request);
        
        return Ok(response);
    }
}