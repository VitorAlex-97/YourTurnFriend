using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourTurnFriend.Application.Features.V1.User.Login;

namespace YourTurnFriend.Presenter.Api.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthenticationController(IMediator _mediator) : ControllerBase
{
    [HttpPost("/Login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest reques)
    {
        var response = await _mediator.Send(reques);

        return Ok(response);
    }
}