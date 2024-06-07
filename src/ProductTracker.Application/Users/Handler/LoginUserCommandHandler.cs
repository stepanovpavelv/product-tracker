using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.Users.Handler;

public sealed class LoginUserCommandHandler(
    IUserRepository userRepository) : IRequestHandler<LoginUserCommand, Result<AuthTokenUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<AuthTokenUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}