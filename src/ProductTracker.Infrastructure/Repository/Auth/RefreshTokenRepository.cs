using LinqToDB;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository.Auth;

/// <inheritdoc cref="IRefreshTokenRepository"/>
internal sealed class RefreshTokenRepository(DatabaseQueryWrapper queryWrapper) : IRefreshTokenRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> SaveUserIdToken(long userId, string refreshToken, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            return (long)await db.UserXrefRefreshTokens
                .InsertAsync(() => new DataModel.UserXrefRefreshToken
                {
                    UserId = userId,
                    RefreshToken = refreshToken
                },
                cancellationToken);
        });
    }
    
    public Task<long> SaveUserIdToken(long userId, string newRefreshToken, string oldRefreshToken, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            return (long)await db.UserXrefRefreshTokens
                .Where(x => x.UserId == userId && x.RefreshToken == oldRefreshToken)
                .Set(x => x.RefreshToken, newRefreshToken)
                .UpdateAsync(cancellationToken);
        });
    }
    
    public Task<RefreshTokenSession> GetUserIdByToken(string refreshToken, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            var record = await db.UserXrefRefreshTokens
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);
            
            return new RefreshTokenSession
            {
                UserId = record?.UserId,
                RefreshToken = refreshToken
            };
        });
    }
    
    public Task<RefreshTokenSession> GetTokenByUserId(long userId, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            var record = await db.UserXrefRefreshTokens
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
            
            return new RefreshTokenSession
            {
                UserId = userId,
                RefreshToken = record?.RefreshToken
            };
        });
    }
}