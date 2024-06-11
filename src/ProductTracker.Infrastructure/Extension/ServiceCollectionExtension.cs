using Microsoft.Extensions.DependencyInjection;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Repository;

namespace ProductTracker.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IHouseRepository, HouseRepository>()
            .AddScoped<IGoodsRepository, GoodsRepository>()
            .AddScoped<IPurchaseRepository, PurchaseRepository>()
            .AddScoped<IRecycleRepository, RecycleRepository>();
}