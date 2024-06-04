using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Repository;

namespace ProductTracker.Infrastructure;

/// <summary>
/// Расширение функциональности для ProductTracker.Infrastructure.
/// </summary>
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IHouseRepository, HouseRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IGoodsRepository, GoodsRepository>();
        services.AddScoped<IRecycleRepository, RecycleRepository>();
        return services;
    }
}