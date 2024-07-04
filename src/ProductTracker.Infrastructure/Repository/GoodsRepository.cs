using LinqToDB;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;
using ProductTracker.Infrastructure.Mapper;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IGoodsRepository" />
internal sealed class GoodsRepository(DatabaseQueryWrapper queryWrapper) : IGoodsRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;
    private readonly GoodsMapper _goodsMapper = new();

    public Task<long> CreateAsync(Goods item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            var model = _goodsMapper.MapDomainToModel(item);
            return (long)await db.Goods.InsertAsync(() => model, token: cancellationToken);
        });
    }

    public Task<Goods> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
            await Task.FromResult(db.Goods
                .Where(x => x.Id == id)
                .AsEnumerable()
                .Select(_goodsMapper.MapModelToDomain)
                .Single())
        );
    }

    public Task<IEnumerable<Goods>> GetAsync(CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync<IEnumerable<Goods>>(async db =>
            await Task.FromResult(
                db.Goods
                   .Select(_goodsMapper.MapModelToDomain)
                   .ToList()
        ));
    }

    public Task<IEnumerable<Goods>> GetAsync(Func<Goods, bool> predicate, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync<IEnumerable<Goods>>(async db =>
            await Task.FromResult(
                db.Goods
                   .Select(_goodsMapper.MapModelToDomain)
                   .Where(predicate)
                   .ToList()
        ));
    }

    public Task<long> RemoveAsync(Goods item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
           (long)await db.Goods
                   .DeleteAsync(x => x.Id == item.Id, cancellationToken)
        );
    }

    public Task<long> UpdateAsync(Goods item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
           (long)await db.Goods
                .Where(x => x.Id == item.Id)
                .Set(x => x.Name, item.Name)
                .Set(x => x.Description, item.Description)
                .UpdateAsync(cancellationToken)
        );
    }
}