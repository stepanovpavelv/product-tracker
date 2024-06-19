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
    private const string auth_error = "Пользователь не авторизован в системе";

    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly IOptions<JwtOption> _option = option;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<RefreshTokenResponse>> Handle(GetRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var principalUser = _contextAccessor.HttpContext?.User;
        if (principalUser == null || principalUser.Identity == null || !principalUser.Identity.IsAuthenticated)
        {
            return Result<RefreshTokenResponse>.Error(auth_error);
        }

        var userLogin = principalUser.FindFirst(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userLogin?.Value))
        {
            return Result<RefreshTokenResponse>.Error(auth_error);
        }

        var usersByCondition = await _userRepository.GetAsync(x => x.Login == userLogin.Value, cancellationToken);
        var usersList = usersByCondition.ToList();
        if (usersList.Count != 1)
        {
            return Result<RefreshTokenResponse>.Error("Зарегистрировано больше 1 пользователя с данным идентификатором");
        }

        var user = usersList.Single();

        var accessToken = _jwtManagerRepository.GenerateAccessToken(user.Login);
        var refreshToken = _jwtManagerRepository.GenerateRefreshToken();

        await _refreshTokenRepository.SaveUserIdToken(user.Id, refreshToken, cancellationToken);

        var result = new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            TokenType = "Bearer"
        };

        return Result<RefreshTokenResponse>.Success(result);
    }
}