using LinqToDB;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository.Auth;

/// <inheritdoc cref="IRefreshTokenRepository"/>
internal sealed class RefreshTokenRepository(DatabaseQueryWrapper queryWrapper) : IRefreshTokenRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long?> GetUserIdByToken(string refreshToken, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            var record = await db.UserXrefRefreshTokens
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);
            return record?.UserId;
        });
    }

    public Task<long> SaveUserIdToken(long userId, string refreshToken, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            return (long)await db.UserXrefRefreshTokens
                .InsertOrUpdateAsync(() => new DataModel.UserXrefRefreshToken
                {
                    UserId = userId,
                    RefreshToken = refreshToken
                },
                t => new DataModel.UserXrefRefreshToken
                {
                    RefreshToken = refreshToken
                },
                cancellationToken);
        });
    }
}