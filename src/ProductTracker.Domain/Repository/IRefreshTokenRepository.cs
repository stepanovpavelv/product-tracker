namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для работы с refresh-токенами.
/// </summary>
public interface IRefreshTokenRepository
{
    /// <summary>
    /// Сохранить refresh-токен для пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="refreshToken">refresh-токен.</param>
    /// <returns>Статус сохранения.</returns>
    Task<bool> SaveUserIdToken(long userId, string refreshToken, CancellationToken cancellationToken);

    /// <summary>
    /// Получить идентификатор пользователя по refresh-токену.
    /// </summary>
    /// <param name="refreshToken">refresh-токен.</param>
    /// <returns>Идентификатор пользователя.</returns>
    Task<long?> GetUserIdByToken(string refreshToken, CancellationToken cancellationToken);
}