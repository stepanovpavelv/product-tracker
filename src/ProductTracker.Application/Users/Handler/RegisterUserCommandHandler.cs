using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Utils;

namespace ProductTracker.Application.Users.Handler;

public sealed class RegisterUserCommandHandler(
    IOptions<JwtOption> option,
    IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, Result<RegisteredUserResponse>>
{
    private readonly JwtOption _setting = option.Value;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<RegisteredUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var isExist = await _userRepository.IsUserExistsByLogin(request.Login, cancellationToken);
        if (isExist)
        {
            return Result<RegisteredUserResponse>.Error($"Пользователь с таким логином уже существует: {request.Login}");
        }

        var hashedPassword = HashingUtils.GetPasswordHash(_setting.Key, request.Password);
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Login = request.Login,
            Birthday = request.DateOfBirth,
            Password = hashedPassword
        };

        long userId = await _userRepository.CreateAsync(user, cancellationToken);

        return Result<RegisteredUserResponse>.Success(new RegisteredUserResponse(userId));
    }
}