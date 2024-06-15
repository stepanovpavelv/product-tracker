using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IPurchaseRepository" />
internal sealed class PurchaseRepository(DatabaseQueryWrapper queryWrapper) : IPurchaseRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(Purchase item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Purchase>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Purchase>> GetAsync(Func<Purchase, bool> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Purchase item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Purchase item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}