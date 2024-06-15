using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IGoodsRepository" />
internal sealed class GoodsRepository(DatabaseQueryWrapper queryWrapper) : IGoodsRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(Goods item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Goods> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Goods>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Goods>> GetAsync(Func<Goods, bool> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Goods item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Goods item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}