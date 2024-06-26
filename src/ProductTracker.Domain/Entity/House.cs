﻿namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен справочной сущности `Дом` (`Локация`).
/// </summary>
public sealed class House : BaseDomainEntity
{
    /// <summary>
    /// Краткое описание.
    /// </summary>
    public required string ShortName { get; init; }

    /// <summary>
    /// Подробный адрес.
    /// </summary>
    public required string FullAddress { get; init; }
}