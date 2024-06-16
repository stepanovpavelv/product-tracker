using ProductTracker.Domain.Repository;

namespace ProductTracker.Infrastructure.Repository.Auth;

/// <inheritdoc cref="IRefreshTokenRepository"/>
internal sealed class RefreshTokenRepository : IRefreshTokenRepository
{
    public Task<long?> GetUserIdByToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveUserIdToken(long userId, string refreshToken)
    {
        throw new NotImplementedException();
    }
}