using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.Users.Handler;

public sealed class RegisterUserCommandHandler(
    IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, Result<RegisteredUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<RegisteredUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}