using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="Goods">`.
/// </summary>
public interface IGoodsRepository : IAsyncGenericRepository<Goods, long>
{ }