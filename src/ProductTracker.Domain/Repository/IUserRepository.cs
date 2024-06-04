using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="User">`.
/// </summary>
public interface IUserRepository : IAsyncGenericRepository<User, long>
{ }