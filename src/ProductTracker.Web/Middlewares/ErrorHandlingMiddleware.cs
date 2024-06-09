using ProductTracker.Domain.Extenstion;
using ProductTracker.Web.Model;
using System.Net.Mime;

namespace ProductTracker.Web.Middlewares;

public sealed class ErrorHandlingMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlingMiddleware> logger,
    IHostEnvironment environment)
{
    private const string ErrorMessage = "Произошла внутренняя ошибка сервере при обработке вашего запроса.";
    private const string ErrorExceptionTextTemplate = "An unexpected exception was thrown: {Message}";

    private static readonly string ApiResponseJson = ApiResponse.InternalServerError(ErrorMessage).ToJson()!;

    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;
    private readonly IHostEnvironment _environment = environment;

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ErrorExceptionTextTemplate, ex.Message);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (_environment.IsDevelopment())
            {
                httpContext.Response.ContentType = MediaTypeNames.Text.Plain;
                await httpContext.Response.WriteAsync(ex.ToString());
            }
            else
            {
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                await httpContext.Response.WriteAsync(ApiResponseJson);
            }
        }
    }
}