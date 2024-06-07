using ProductTracker.Application.Common;

namespace ProductTracker.Application.Users.Response;

/// <summary>
/// Ответ системы на регистрацию/аутетификацию пользователя.
/// </summary>
public sealed class AuthTokenUserResponse : IResponse
{
    public required string AccessToken { get; init; }

    public required string BearerToken { get; init; }
}