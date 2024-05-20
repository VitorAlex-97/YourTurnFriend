using MediatR;
using YourTurnFriend.Application.Commons.Exceptions;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Contracts.Persistence;
using YourTurnFriend.Domain.Contracts.Services.Cryptography;
using YourTurnFriend.Domain.Repositories;
using Entity = YourTurnFriend.Domain.Entities.User.User;

namespace YourTurnFriend.Application.Features.V1.User.Create;

public class CreateUserHandler
(
    IUserRepository userRepository,
    ICryptographyService cryptographyService,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateUserRequest, Response<CreateUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICryptographyService _cryptographyService = cryptographyService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<CreateUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userAlreadyExists = await _userRepository.ExistsByUsernameAsync(
                                            username: request.Username, 
                                            cancellationToken: cancellationToken
                                        );

        if (userAlreadyExists)
        {
            throw new BusinessException($"Username is not available.");
        }

        if (request.Password != request.ConfirmPassword)
        {
            throw new BusinessException($"Passwords divergentes.");
        }

        Entity.ValidateFormatePassword(request.Password);

        var passwordHashed = await _cryptographyService.EncryptAsync(request.Password, cancellationToken);

        var newUser = new Entity(
                                username: request.Username,
                                password: passwordHashed ?? string.Empty
                            );

        await _userRepository.AddAsync(newUser, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Response<CreateUserResponse>.Success(new CreateUserResponse(newUser.Id));
    }
}