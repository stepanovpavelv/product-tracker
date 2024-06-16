using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;
using ProductTracker.Utils;

namespace ProductTracker.Application.Users.Handler;

public sealed class LoginUserCommandHandler(
    IOptions<JwtOption> option,
    IUserRepository userRepository,
    IJwtManagerRepository jwtManagerRepository,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<LoginUserCommand, Result<AuthTokenUserResponse>>
{
    private readonly JwtOption _setting = option.Value;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<AuthTokenUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var user = await _userRepository.GetByLogin(request.Login, cancellationToken);
        if (user == null)
        {
            return Result<AuthTokenUserResponse>.Error($"Пользователя с таким логином не зарегистрирован: {request.Login}");
        }

        var hashedPassword = HashingUtils.GetPasswordHash(_setting.Key, request.Password);
        if (!string.Equals(user.Password, hashedPassword)) {
            return Result<AuthTokenUserResponse>.Error($"Введен некорректный пароль для пользователя: {request.Login}");
        }

        var accessToken = _jwtManagerRepository.GenerateAccessToken(user.Login);
        var refreshToken = _jwtManagerRepository.GenerateRefreshToken();

        await _refreshTokenRepository.SaveUserIdToken(user.Id, refreshToken, cancellationToken);

        var result = new AuthTokenUserResponse
        { 
            AccessToken = accessToken, 
            RefreshToken = refreshToken 
        };

        return Result<AuthTokenUserResponse>.Success(result);
    }
}