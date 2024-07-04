using ProductTracker.Domain.Entity;
using Riok.Mapperly.Abstractions;
using GoodsModel = DataModel.Good;

namespace ProductTracker.Infrastructure.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public partial class GoodsMapper
{
    public partial Goods MapModelToDomain(GoodsModel source);

    public partial GoodsModel MapDomainToModel(Goods source);
}