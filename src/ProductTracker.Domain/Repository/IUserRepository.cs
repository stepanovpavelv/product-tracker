using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение репозитория для взаимодействия с сущностью `<see cref="User">`.
/// </summary>
public interface IUserRepository : IAsyncGenericRepository<User, long>
{
    Task<bool> IsExistsByLogin(string login, CancellationToken cancellationToken);

    Task<User?> GetByLogin(string login, CancellationToken cancellationToken);
}