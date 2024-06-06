namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Совершенная покупка`.
/// </summary>
public sealed class Purchase : BaseDomainEntity
{
    /// <summary>
    /// Ссылка на дом, где хранится продукт.
    /// </summary>
    public required House House { get; init; }

    /// <summary>
    /// Дата покупки.
    /// </summary>
    public required DateOnly BoughtDate { get; init; }

    /// <summary>
    /// Купленные продукты.
    /// </summary>
    public required List<Product> Products { get; init; }
}