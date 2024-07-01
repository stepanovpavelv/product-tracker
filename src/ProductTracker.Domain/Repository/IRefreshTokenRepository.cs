using ProductTracker.Domain.Entity;

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
    /// <param name="cancellationToken">токен отмены операции.</param>
    /// <returns>Статус сохранения.</returns>
    Task<long> SaveUserIdToken(long userId, string refreshToken, CancellationToken cancellationToken);
    
    /// <summary>
    /// Сохранить refresh-токен для пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="newRefreshToken">новый refresh-токен.</param>
    /// <param name="oldRefreshToken">старый refresh-токен.</param>
    /// <param name="cancellationToken">токен отмены операции.</param>
    /// <returns>Статус сохранения.</returns>
    Task<long> SaveUserIdToken(long userId, string newRefreshToken, string oldRefreshToken, CancellationToken cancellationToken);

    /// <summary>
    /// Получить идентификатор пользователя по refresh-токену.
    /// </summary>
    /// <param name="refreshToken">refresh-токен.</param>
    /// <param name="cancellationToken">токен отмены операции.</param>
    /// <returns>Идентификатор пользователя.</returns>
    Task<RefreshTokenSession> GetUserIdByToken(string refreshToken, CancellationToken cancellationToken);

    /// <summary>
    /// Получить refresh-токен по идентификатору пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">токен отмены операции.</param>
    /// <returns>refresh-токен</returns>
    Task<RefreshTokenSession> GetTokenByUserId(long userId, CancellationToken cancellationToken);
}