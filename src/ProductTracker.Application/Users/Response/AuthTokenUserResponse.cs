using ProductTracker.Application.Common;

namespace ProductTracker.Application.Users.Response;

/// <summary>
/// Ответ системы на регистрацию/аутентификацию пользователя.
/// </summary>
public sealed class AuthTokenUserResponse : IResponse
{
    public required string AccessToken { get; init; }

    public required string RefreshToken { get; init; }
}