using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="Purchase">`.
/// </summary>
public interface IPurchaseRepository : IAsyncGenericRepository<Purchase, long>
{ }