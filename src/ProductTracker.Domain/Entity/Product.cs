﻿namespace ProductTracker.Domain.Entity;

/// <summary>
/// Домен сущности `Купленный продукт`.
/// </summary>
public sealed class Product : BaseDomainEntity
{
    /// <summary>
    /// Ссылка на товар.
    /// </summary>
    public required Goods Goods { get; init; }

    /// <summary>
    /// Срок годности.
    /// </summary>
    public required DateOnly ExpireDate { get; init; }
}