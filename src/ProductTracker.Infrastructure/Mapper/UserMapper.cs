using ProductTracker.Domain.Entity;
using Riok.Mapperly.Abstractions;
using UserModel = DataModel.User;

namespace ProductTracker.Infrastructure.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public partial class UserMapper
{
    [MapperIgnoreSource(nameof(UserModel.HouseXrefUsers))]
    [MapperIgnoreSource(nameof(UserModel.UserXrefRefreshTokens))]
    [MapProperty(nameof(UserModel.BirthDay), nameof(User.Birthday), Use = nameof(MapBirthday))]
    public partial User MapModelToDomain(UserModel source);

    [UserMapping(Default = false)]
    private DateOnly MapBirthday(DateTime datetime)
        => DateOnly.FromDateTime(datetime);
}