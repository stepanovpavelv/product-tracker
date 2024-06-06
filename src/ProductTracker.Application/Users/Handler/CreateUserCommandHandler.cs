using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.Users.Handler;

public sealed class CreateUserCommandHandler(
    IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<CreatedUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<CreatedUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}