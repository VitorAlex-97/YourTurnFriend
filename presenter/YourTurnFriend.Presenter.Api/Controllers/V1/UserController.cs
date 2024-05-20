using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Application.Features.V1.User.Create;

namespace YourTurnFriend.Presenter.Api.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<Response<CreateUserResponse>>> Create
    (
        [FromBody] CreateUserRequest request        
    )
    {
        var response = await _mediator.Send(request);

        return CreatedAtAction(nameof(Create), response);
    }
}