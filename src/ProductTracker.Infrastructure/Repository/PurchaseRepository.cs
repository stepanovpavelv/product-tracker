using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IPurchaseRepository" />
internal sealed class PurchaseRepository(DatabaseQueryWrapper queryWrapper) : IPurchaseRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Purchase>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Purchase>> GetAsync(Func<Purchase, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Purchase item)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Purchase item)
    {
        throw new NotImplementedException();
    }
}