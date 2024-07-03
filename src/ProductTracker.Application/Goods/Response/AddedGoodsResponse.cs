using ProductTracker.Application.Common;

namespace ProductTracker.Application.Goods.Response;

/// <summary>
/// Ответ системы на добавление нового товара.
/// </summary>
public sealed class AddedGoodsResponse(long id) : IResponse
{
    /// <summary>
    /// Уникальный идентификатор товара.
    /// </summary>
    public long Id { get; } = id;
}