using Ardalis.Result;
using MediatR;
using ProductTracker.Application.User.Command;
using ProductTracker.Application.User.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.User.Handler;

public sealed class CreateUserCommandHandler(
    IUserRepository userRepository) : IRequestHandler<CreateCustomerCommand, Result<CreatedUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public Task<Result<CreatedUserResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}