using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ProductTracker.Application.Common;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var commandName = GetGenericTypeName(request);

        logger.LogInformation("----- Обработка команды '{CommandName}'", commandName);

        var timer = new Stopwatch();
        timer.Start();

        var response = await next();

        timer.Stop();

        var timeTaken = timer.Elapsed.TotalSeconds;
        logger.LogInformation("----- Команда '{CommandName}' обработана за ({TimeTaken} секунд)", commandName, timeTaken);

        return response;
    }

    /// <summary>
    /// Returns the name of the generic type of the object.
    /// </summary>
    /// <param name="object">The object to get the generic type name from.</param>
    /// <returns>The name of the generic type.</returns>
    private static string GetGenericTypeName(object @object)
    {
        var type = @object.GetType();

        // Check if the type is not generic
        if (!type.IsGenericType)
            return type.Name;

        // Get the names of the generic arguments and join them with commas
        var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());

        // Remove the backtick and append the generic arguments to the type name
        return $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
    }
}