namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с токенами аутентификации.
/// </summary>
public interface IJwtManagerRepository
{
    /// <summary>
    /// Генерация токена доступа к объектам системы.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Токен для доступа к объектам системы.</returns>
    string GenerateAccessToken(string userLogin);

    /// <summary>
    /// Генерация токена для обновления аутентификационных данных.
    /// </summary>
    /// <returns>Токен для обновления.</returns>
    string GenerateRefreshToken();
}