using System.Security.Claims;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;
using ProductTracker.Application.Auth.Command;
using ProductTracker.Application.Auth.Response;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;

namespace ProductTracker.Application.Auth.Handler;

/// <summary>
/// Получение идентификационных данных пользователя.
/// </summary>
/// <param name="option"></param>
/// <param name="userRepository"></param>
/// <param name="jwtManagerRepository"></param>
/// <param name="refreshTokenRepository"></param>
public sealed class GetRefreshTokenHandler(
    IHttpContextAccessor contextAccessor,
    IOptions<JwtOption> option,
    IUserRepository userRepository,
    IJwtManagerRepository jwtManagerRepository,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<GetRefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private const string AuthError = "Пользователь не авторизован в системе";

    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<RefreshTokenResponse>> Handle(GetRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var principalUser = _contextAccessor.HttpContext?.User;
        if (principalUser?.Identity is not { IsAuthenticated: true })
        {
            return Result<RefreshTokenResponse>.Error(AuthError);
        }

        var userLogin = principalUser.FindFirst(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userLogin?.Value))
        {
            return Result<RefreshTokenResponse>.Error(AuthError);
        }

        var usersByCondition = await _userRepository.GetAsync(x => x.Login == userLogin.Value, cancellationToken);
        var usersList = usersByCondition.ToList();
        if (usersList.Count != 1)
        {
            return Result<RefreshTokenResponse>.Error("Зарегистрировано больше 1 пользователя с данным идентификатором");
        }

        var user = usersList.Single();

        var accessToken = _jwtManagerRepository.GenerateAccessToken(user.Login);
        var newRefreshToken = _jwtManagerRepository.GenerateRefreshToken();

        var tokenSession = await _refreshTokenRepository.GetTokenByUserId(user.Id, cancellationToken);
        if (string.IsNullOrEmpty(tokenSession.RefreshToken))
        {
            await _refreshTokenRepository.SaveUserIdToken(user.Id, newRefreshToken, cancellationToken);
        }
        else
        {
            await _refreshTokenRepository.SaveUserIdToken(user.Id, newRefreshToken, tokenSession.RefreshToken, cancellationToken);
        }

        var result = new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            TokenType = "Bearer"
        };

        return Result<RefreshTokenResponse>.Success(result);
    }
}