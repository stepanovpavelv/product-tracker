using System.IO.Compression;
using System.Text.Json.Serialization;
using FluentValidation;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using ProductTracker.Application.Extension;
using ProductTracker.Domain.Extenstion;
using ProductTracker.Infrastructure;
using ProductTracker.Infrastructure.Extension;
using ProductTracker.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<GzipCompressionProviderOptions>(compressionOptions => compressionOptions.Level = CompressionLevel.Fastest)
    .Configure<JsonOptions>(jsonOptions => jsonOptions.JsonSerializerOptions.Configure())
    .Configure<RouteOptions>(routeOptions => routeOptions.LowercaseUrls = true)
    //.AddHttpClient()
    .AddHttpContextAccessor()
    .AddResponseCompression(compressionOptions =>
    {
        compressionOptions.EnableForHttps = true;
        compressionOptions.Providers.Add<GzipCompressionProvider>();
    })
    .AddEndpointsApiExplorer()
    //.AddApiVersioning(versioningOptions =>
    //{
    //    versioningOptions.DefaultApiVersion = ApiVersion.Default;
    //    versioningOptions.ReportApiVersions = true;
    //    versioningOptions.AssumeDefaultVersionWhenUnspecified = true;
    //})
    //.AddVersionedApiExplorer(explorerOptions =>
    //{
    //    explorerOptions.GroupNameFormat = "'v'VVV";
    //    explorerOptions.SubstituteApiVersionInUrl = true;
    //})
    .AddSwagger();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(behaviorOptions =>
    {
        behaviorOptions.SuppressMapClientErrors = true;
        behaviorOptions.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Adding the application services in ASP.NET Core DI.
builder.Services
    .ConfigureAppSettings()
    .AddCorrelationGenerator()
    .AddInfrastructure()
    .AddCommandHandlers();
    //.AddQueryHandlers()
    //.AddWriteDbContext()
    //.AddWriteOnlyRepositories()
    //.AddReadDbContext()
    //.AddReadOnlyRepositories()
    //.AddHealthChecks(builder.Configuration);

// Validating the services added in the ASP.NET Core DI.
builder.Host.UseDefaultServiceProvider((context, serviceProviderOptions) =>
{
    serviceProviderOptions.ValidateScopes = context.HostingEnvironment.IsDevelopment();
    serviceProviderOptions.ValidateOnBuild = true;
});

// Using the Kestrel Server (linux).
builder.WebHost.UseKestrel(kestrelOptions => kestrelOptions.AddServerHeader = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseErrorHandling();
app.UseSwagger();
app.UseSwaggerUI();
app.UseResponseCompression();
//app.UseHttpsRedirection();
app.UseCorrelationId();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();