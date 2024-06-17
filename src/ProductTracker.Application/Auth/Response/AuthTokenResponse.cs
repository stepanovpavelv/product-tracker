using ProductTracker.Application.Common;

namespace ProductTracker.Application.Auth.Response;

/// <summary>
/// Ответ системы на регистрацию/аутентификацию пользователя.
/// </summary>
public sealed class AuthTokenResponse : IResponse
{
    /// <summary>
    /// Аутентификационный токен.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// Токен для обновления данных.
    /// </summary>
    public required string RefreshToken { get; init; }
}