using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Contracts.Services.Cryptography;
using YourTurnFriend.Domain.Contracts.Services.Security;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.User.Login;

public sealed class LoginHandler
(
    IUserRepository _userRepository, 
    ICryptographyService _cryptographyService,
    ITokenService _tokenService
) 
: IRequestHandler<LoginRequest, Response<LoginResponse>>
{
    public async Task<Response<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetOneAsync(
                            username: request.Username,
                            cancellationToken: cancellationToken
                        ) ?? throw new BusinessException("User not found.");

        var passwordIsValid = await _cryptographyService.CompareAsync(
                                    source: request.Password,
                                    target: user.Password,
                                    cancellationToken: cancellationToken
                                );
        
        if (!passwordIsValid)
        {
            throw new BusinessException($"{nameof(user.Username)} or {nameof(user.Password)} is invalid.");
        }

        var token = await _tokenService.GenerateTokenAsync(user: user, cancellationToken: cancellationToken);

        return Response<LoginResponse>.Success(new(token));
    }
}