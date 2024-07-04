using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Goods.Response;

namespace ProductTracker.Application.Goods.Command;

/// <summary>
/// Команда на создание товара.
/// </summary>
public sealed class AddGoodsCommand : IRequest<Result<AddedGoodsResponse>>
{
    /// <summary>
    /// Название товара.
    /// </summary>
    [Required]
    [MaxLength(200)]
    [DataType(DataType.Text)]
    public required string Name { get; set; }

    /// <summary>
    /// Описание товара.
    /// </summary>
    [DataType(DataType.Text)]
    public string? Description { get; set; }
}