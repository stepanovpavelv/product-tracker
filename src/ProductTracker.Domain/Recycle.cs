namespace ProductTracker.Domain;

/// <summary>
/// Домен сущности `Утилизация`.
/// </summary>
public sealed class Recycle : BaseDomainEntity
{
    /// <summary>
    /// Купленный товар.
    /// </summary>
    public required Purchase Purchase { get; set; }

    /// <summary>
    /// Срок его утилизации/либо употребления.
    /// </summary>
    public required DateOnly RecycleDate { get; set; }
}