using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;

namespace YourTurnFriend.Application.Features.V1.User.Create;

public record CreateUserRequest
(
    string Username,
    string Password,
    string ConfirmPassword
) : IRequest<Response<object>>;