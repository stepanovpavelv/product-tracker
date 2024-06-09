using Microsoft.Extensions.Primitives;
using ProductTracker.Domain.Shared;

namespace ProductTracker.Web.Middlewares;

public sealed class CorrelationIdMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderKey = "X-Correlation-Id";

    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext httpContext, CorrelationIdGenerator correlationIdGenerator)
    {
        var correlationId = GetCorrelationId(httpContext, correlationIdGenerator);

        httpContext.Response.OnStarting(() =>
        {
            httpContext.Response.Headers.Append(CorrelationIdHeaderKey, new[] { correlationId.ToString() });
            return Task.CompletedTask;
        });

        await _next(httpContext);
    }

    private static StringValues GetCorrelationId(HttpContext httpContext, CorrelationIdGenerator correlationIdGenerator)
    {
        if (httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out var correlationId))
        {
            var correlationValue = correlationId.ToString();
            correlationIdGenerator.Set(correlationValue);
            return correlationId;
        }

        return correlationIdGenerator.Get();
    }
}
