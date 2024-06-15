using ProductTracker.Domain.Entity;

namespace ProductTracker.Domain.Repository;

/// <summary>
/// Поведение обобщенного репозитория (паттерн).
/// </summary>
/// <typeparam name="TEntity">Класс доменной сущности.</typeparam>
/// <typeparam name="TKey">Тип идентификатора.</typeparam>
public interface IAsyncGenericRepository<TEntity, TKey> where TEntity : BaseDomainEntity
{
    /// <summary>
    /// Сохранение сущности.
    /// </summary>
    /// <param name="item">Объект сущности.</param>
    /// <returns>Идентификатор созданной сущности.</returns>
    Task<TKey> CreateAsync(TEntity item, CancellationToken cancellationToken);
    
    /// <summary>
    /// Найти сущность по идентификатору.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <returns>Сущность.</returns>
    Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить полную коллекцию сущностей.
    /// </summary>
    /// <returns>Коллекция сущностей.</returns>
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить коллекцию сущностей по условию (предикату).
    /// </summary>
    /// <param name="predicate">Условие получения.</param>
    /// <returns>Коллекция сущностей.</returns>
    Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="item">Сущность.</param>
    Task<TKey> RemoveAsync(TEntity item, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="item">Сущность.</param>
    Task<TKey> UpdateAsync(TEntity item, CancellationToken cancellationToken);
}