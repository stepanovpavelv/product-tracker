using ProductTracker.Domain.Entity;
using System.Security.Claims;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью <see cref="TokenSession"/>
/// </summary>
public interface IJwtManagerRepository
{
    TokenSession GenerateToken(string userName);
    //TokenSession GenerateRefreshToken(string userName);

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}