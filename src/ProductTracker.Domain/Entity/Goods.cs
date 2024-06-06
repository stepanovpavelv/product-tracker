namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен справочной сущности `Товар`.
/// </summary>
public sealed class Goods : BaseDomainEntity
{
    /// <summary>
    /// Наименование товара.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Краткое описание.
    /// </summary>
    public required string Description { get; init; }
}