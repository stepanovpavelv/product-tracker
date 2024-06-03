namespace ProductTracker.Domain;

/// <summary>
/// Домен справочной сущности `Товар`.
/// </summary>
public sealed class Goods : BaseDomainEntity
{
    /// <summary>
    /// Наименование товара.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Краткое описание.
    /// </summary>
    public required string Description { get; set; }
}