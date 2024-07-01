namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Токен` пользователя.
/// </summary>
public sealed class RefreshTokenSession
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public long? UserId { get; init; }

    /// <summary>
    /// Токен для восстановления аутентификации пользователя.
    /// </summary>
    public string? RefreshToken { get; init; }
}