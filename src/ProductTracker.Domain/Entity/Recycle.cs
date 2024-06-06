namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Утилизация`.
/// </summary>
public sealed class Recycle : BaseDomainEntity
{
    /// <summary>
    /// Купленный товар.
    /// </summary>
    public required Product Product { get; init; }

    /// <summary>
    /// Срок его утилизации/либо употребления.
    /// </summary>
    public required DateOnly RecycleDate { get; init; }
}