namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Токен` пользователя.
/// </summary>
public sealed class TokenSession
{
    /// <summary>
    /// Токен-подтверждение о прошедшей аунтентификации.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// Токен для восстановления аутентификации пользователя.
    /// </summary>
    public required string RefreshToken { get; init; }
}