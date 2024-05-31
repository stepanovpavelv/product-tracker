namespace ProductTracker.Domain;

/// <summary>
/// Модели сущности `Утилизация`.
/// </summary>
public sealed class Recycle : BaseEntity
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