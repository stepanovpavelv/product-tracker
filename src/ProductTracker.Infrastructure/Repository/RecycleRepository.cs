using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IRecycleRepository" />
internal sealed class RecycleRepository(DatabaseQueryWrapper queryWrapper) : IRecycleRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(Recycle item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Recycle> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recycle>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recycle>> GetAsync(Func<Recycle, bool> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Recycle item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Recycle item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}