using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IUserRepository"/>
internal sealed class UserRepository(DatabaseQueryWrapper queryWrapper) : IUserRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(User item)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(Func<User, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(User item)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(User item)
    {
        throw new NotImplementedException();
    }
}