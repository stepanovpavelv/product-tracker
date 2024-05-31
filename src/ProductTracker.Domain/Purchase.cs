namespace ProductTracker.Domain;

/// <summary>
/// Модель сущности `Купленный товар`.
/// </summary>
public sealed class Purchase : BaseEntity
{
    /// <summary>
    /// Ссылка на товар.
    /// </summary>
    public required Goods Product { get; set; }

    /// <summary>
    /// Дата покупки.
    /// </summary>
    public required DateOnly BoughtDate { get; set; }

    /// <summary>
    /// Срок годности.
    /// </summary>
    public required DateOnly ExpireDate { get; set; }
}