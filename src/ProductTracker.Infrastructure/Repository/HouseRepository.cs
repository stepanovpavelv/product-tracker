using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IHouseRepository" />
internal sealed class HouseRepository : IHouseRepository
{
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