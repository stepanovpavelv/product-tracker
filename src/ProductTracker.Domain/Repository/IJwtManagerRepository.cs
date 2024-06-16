namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с токенами аутентификации.
/// </summary>
public interface IJwtManagerRepository
{
    string GenerateAccessToken(string userLogin);

    string GenerateRefreshToken();
}