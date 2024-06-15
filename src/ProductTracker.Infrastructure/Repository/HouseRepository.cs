using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IHouseRepository" />
internal sealed class HouseRepository(DatabaseQueryWrapper queryWrapper) : IHouseRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(House item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<House> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<House>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<House>> GetAsync(Func<House, bool> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(House item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(House item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}