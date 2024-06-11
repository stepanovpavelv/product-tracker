using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IHouseRepository" />
internal sealed class HouseRepository(DatabaseQueryWrapper queryWrapper) : IHouseRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(House item)
    {
        throw new NotImplementedException();
    }

    public Task<House> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<House>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<House>> GetAsync(Func<House, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(House item)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(House item)
    {
        throw new NotImplementedException();
    }
}