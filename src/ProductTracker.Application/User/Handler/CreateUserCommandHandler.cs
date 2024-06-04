using Ardalis.Result;
using MediatR;
using ProductTracker.Application.User.Command;
using ProductTracker.Application.User.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.User.Handler;

public sealed class CreateUserCommandHandler(
    IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<CreatedUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<CreatedUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}