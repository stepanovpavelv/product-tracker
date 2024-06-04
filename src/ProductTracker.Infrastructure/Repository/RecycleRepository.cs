using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IRecycleRepository" />
internal sealed class RecycleRepository : IRecycleRepository
{
    public Task<long> CreateAsync(Recycle item)
    {
        throw new NotImplementedException();
    }

    public Task<Recycle> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recycle>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Recycle>> GetAsync(Func<Recycle, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Recycle item)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Recycle item)
    {
        throw new NotImplementedException();
    }
}