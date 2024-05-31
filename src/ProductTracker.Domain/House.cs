namespace ProductTracker.Domain;

/// <summary>
/// Модель справочной сущности `Дом` (`Локация`).
/// </summary>
public sealed class House : BaseEntity
{
    /// <summary>
    /// Краткое описание.
    /// </summary>
    public required string ShortName { get; set; }

    /// <summary>
    /// Подробный адрес.
    /// </summary>
    public required string FullAddress { get; set; }
}