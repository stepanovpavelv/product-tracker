using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

namespace ProductTracker.Infrastructure;

/// <summary>
/// Настройки приложения
/// </summary>
public sealed class ApplicationConfig
{
    private const string PRODUCTS_LAB_DB_SETTING_NAME = "products-db";

    public string? PostgresConnectionString { get; }
    public string? Env { get; }

    /// <summary>
    /// Конструктор класса <see cref="ApplicationConfig"/>
    /// </summary>
    public ApplicationConfig(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        configuration.AddEnvironmentVariables();

        Env = configuration.GetValue<string>("Env") ?? "local";

        PostgresConnectionString = SetConnectionString(configuration, PRODUCTS_LAB_DB_SETTING_NAME);
    }

    private static string SetConnectionString(IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString(name);
        return connectionString
            ?? throw new Exception($"{name} connection string is not provided!");
    }
}
