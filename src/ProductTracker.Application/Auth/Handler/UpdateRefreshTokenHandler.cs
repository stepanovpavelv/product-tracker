using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Auth.Command;
using ProductTracker.Application.Auth.Response;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Application.Auth.Handler;

/// <summary>
/// Обновление идентификационных данных пользователя.
/// </summary>
public sealed class UpdateRefreshTokenHandler(
    IUserRepository userRepository,
    IJwtManagerRepository jwtManagerRepository,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<UpdateRefreshTokenCommand, Result<RefreshTokenResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<RefreshTokenResponse>> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var tokenSession = await _refreshTokenRepository.GetUserIdByToken(request.RefreshToken, cancellationToken);
        if (tokenSession.UserId == null)
        {
            return Result<RefreshTokenResponse>.NotFound($"Данный refresh-токен не зарегистрирован в системе: {request.RefreshToken}");
        }

        var userId = tokenSession.UserId.Value;
        var usersByCondition = await _userRepository.GetAsync(x => x.Id == userId, cancellationToken);
        var usersList = usersByCondition.ToList();
        if (usersList.Count != 1)
        {
            return Result<RefreshTokenResponse>.Error("Зарегистрировано больше 1 пользователя с данным идентификатором");
        }

        var user = usersList.Single();

        var accessToken = _jwtManagerRepository.GenerateAccessToken(user.Login);
        var newRefreshToken = _jwtManagerRepository.GenerateRefreshToken();

        await _refreshTokenRepository.SaveUserIdToken(user.Id, newRefreshToken, request.RefreshToken, cancellationToken);

        var result = new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            TokenType = "Bearer"
        };

        return Result<RefreshTokenResponse>.Success(result);
    }
}