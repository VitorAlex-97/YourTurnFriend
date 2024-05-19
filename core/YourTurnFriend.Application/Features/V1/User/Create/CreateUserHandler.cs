using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using YourTurnFriend.Application.Commons.Wrappers;
using YourTurnFriend.Domain.Repositories;

namespace YourTurnFriend.Application.Features.V1.User.Create;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, Response<object>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<Response<object>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}