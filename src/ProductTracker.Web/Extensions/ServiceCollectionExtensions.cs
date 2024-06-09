using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace ProductTracker.Web.Extensions;

[ExcludeFromCodeCoverage]
internal static class ServicesCollectionExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Product Tracker",
                Description = "This application uses ASP.NET Core C# CQRS Event Sourcing, REST API, DDD, SOLID Principles and Clean Architecture",
                Contact = new OpenApiContact
                {
                    Name = "Pavel Stepanov",
                    Email = "stepanov.pavel.v@inbox.ru"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License"
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            swaggerOptions.IncludeXmlComments(xmlPath, true);
        });
    }
}