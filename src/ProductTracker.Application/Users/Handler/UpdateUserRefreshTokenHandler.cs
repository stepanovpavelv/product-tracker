using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.Users.Handler;

/// <summary>
/// Обновление идентификационных данных пользователя.
/// </summary>
public sealed class UpdateUserRefreshTokenHandler(
    IOptions<JwtOption> option,
    IUserRepository userRepository,
    IJwtManagerRepository jwtManagerRepository,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<UpdateUserRefreshTokenCommand, Result<AuthTokenUserResponse>>
{
    private readonly IOptions<JwtOption> _option = option;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<AuthTokenUserResponse>> Handle(UpdateUserRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var userId = await _refreshTokenRepository.GetUserIdByToken(request.RefreshToken, cancellationToken);
        if (userId == null)
        {
            return Result<AuthTokenUserResponse>.Error($"Данный refresh-токен не зарегистрирован в системе: {request.RefreshToken}");
        }

        var usersByCondition = (await _userRepository.GetAsync(x => x.Id == userId, cancellationToken)).ToList();
        if (usersByCondition.Count != 1)
        {
            return Result<AuthTokenUserResponse>.Error("Зарегистрировано больше 1 пользователя с данным идентификатором");
        }

        var user = usersByCondition.Single();

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