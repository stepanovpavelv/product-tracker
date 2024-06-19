using Microsoft.Extensions.Configuration;
using ProductTracker.Domain.Shared;

namespace ProductTracker.Domain.Extenstion;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Получить настройки из объекта IConfiguration.
    /// </summary>
    /// <typeparam name="TOptions">Тип настроек для получения.</typeparam>
    /// <param name="configuration">Объект IConfiguration.</param>
    /// <returns>Объект с настройками.</returns>
    public static TOptions? GetOptions<TOptions>(this IConfiguration configuration)
        where TOptions : class, IApplicationOption
    {
        return configuration
            .GetRequiredSection(TOptions.ConfigSectionPath)
            .Get<TOptions>(options => options.BindNonPublicProperties = true);
    }
}