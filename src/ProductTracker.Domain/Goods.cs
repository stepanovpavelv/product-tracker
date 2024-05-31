namespace ProductTracker.Domain;

/// <summary>
/// Модель справочной сущности `Товар` (`Продукт`).
/// </summary>
public sealed class Goods : BaseEntity
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