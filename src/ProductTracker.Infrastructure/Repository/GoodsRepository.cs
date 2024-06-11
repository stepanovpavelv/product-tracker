using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IGoodsRepository" />
internal sealed class GoodsRepository(DatabaseQueryWrapper queryWrapper) : IGoodsRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<long> CreateAsync(Goods item)
    {
        throw new NotImplementedException();
    }

    public Task<Goods> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Goods>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Goods>> GetAsync(Func<Goods, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(Goods item)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(Goods item)
    {
        throw new NotImplementedException();
    }
}