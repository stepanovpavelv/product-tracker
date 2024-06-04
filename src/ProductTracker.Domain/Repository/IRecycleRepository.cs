using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="Recycle">`.
/// </summary>
public interface IRecycleRepository : IAsyncGenericRepository<Recycle, long>
{ }