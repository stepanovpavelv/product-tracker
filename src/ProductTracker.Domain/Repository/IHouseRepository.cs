using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="House">`.
/// </summary>
public interface IHouseRepository : IAsyncGenericRepository<House, long>
{ }