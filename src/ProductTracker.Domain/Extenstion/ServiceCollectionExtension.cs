using Microsoft.Extensions.DependencyInjection;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Shared;

namespace ProductTracker.Domain.Extenstion;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCorrelationGenerator(this IServiceCollection services) =>
        services.AddScoped<CorrelationIdGenerator>();

    public static IServiceCollection ConfigureAppSettings(this IServiceCollection services) =>
        services
            .AddOptionsWithValidation<ConnectionOption>()
            .AddOptionsWithValidation<JwtOption>();

    /// <summary>
    /// Валировать и зарегистрировать экземпляр фрагмента конфигурации приложения.
    /// </summary>
    /// <typeparam name="TOptions">Тип фрагмента конфигурации.</typeparam>
    /// <param name="services">Перечень регистраций.</param>
    private static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services)
        where TOptions : class, IApplicationOption
    {
        return services
            .AddOptions<TOptions>()
            .BindConfiguration(TOptions.ConfigSectionPath, binderOptions => binderOptions.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
    }
}