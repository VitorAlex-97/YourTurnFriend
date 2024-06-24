using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;

namespace YourTurnFriend.Application.Features.V1.User.Login;

public sealed record LoginRequest
(
    string Username,
    string Password
) : IRequest<Response<LoginResponse>>;