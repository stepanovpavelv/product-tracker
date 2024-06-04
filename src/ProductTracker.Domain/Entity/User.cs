namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Пользователь`.
/// </summary>
public sealed class User : BaseDomainEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly Birthday { get; set; }
}