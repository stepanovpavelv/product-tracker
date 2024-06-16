using Microsoft.Extensions.DependencyInjection;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;
using ProductTracker.Infrastructure.Repository;
using ProductTracker.Infrastructure.Repository.Auth;

namespace ProductTracker.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddScoped<DatabaseQueryWrapper>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IHouseRepository, HouseRepository>()
            .AddScoped<IGoodsRepository, GoodsRepository>()
            .AddScoped<IPurchaseRepository, PurchaseRepository>()
            .AddScoped<IRecycleRepository, RecycleRepository>()
            .AddScoped<IJwtManagerRepository, JwtManagerRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
}