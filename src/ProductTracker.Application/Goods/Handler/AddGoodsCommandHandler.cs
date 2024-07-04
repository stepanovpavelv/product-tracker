using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Application.Goods.Command;
using ProductTracker.Application.Goods.Response;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;
using GoodsDomain = ProductTracker.Domain.Entity.Goods;

namespace ProductTracker.Application.Goods.Handler;

/// <summary>
/// Добавление нового товара.
/// </summary>
public sealed class AddGoodsCommandHandler(
    IOptions<JwtOption> option,
    IGoodsRepository goodsRepository) : IRequestHandler<AddGoodsCommand, Result<AddedGoodsResponse>>
{
    private readonly JwtOption _setting = option.Value;
    private readonly IGoodsRepository _goodsRepository = goodsRepository;

    public async Task<Result<AddedGoodsResponse>> Handle(AddGoodsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var foundGoods = await _goodsRepository.GetAsync(x => string.Equals(x.Name, request.Name, StringComparison.OrdinalIgnoreCase), cancellationToken);
        if (foundGoods != null && foundGoods.Any())
            return Result<AddedGoodsResponse>.Conflict("Товар с таким наименованием уже присутствует в системе");

        var goods = new GoodsDomain
        {
            Name = request.Name,
            Description = request.Description
        };
        long id = await _goodsRepository.CreateAsync(goods, cancellationToken);
        
        return Result<AddedGoodsResponse>.Success(new AddedGoodsResponse(id));
    }
}