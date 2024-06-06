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

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public required string Login { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    /// <remarks>
    ///     Он будет заполнен только при создании/изменении доменной сущности.
    ///     В остальных случаях нет надобности заполнять.
    /// </remarks>
    public string? Password { get; set; }
}