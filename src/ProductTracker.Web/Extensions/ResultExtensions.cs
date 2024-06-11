using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using ProductTracker.Web.Model;
using IResult = Ardalis.Result.IResult;

namespace ProductTracker.Web.Extensions;

internal static class ResultExtensions
{
    /// <summary>
    /// Преобразовывает кастомный объект класса <see cref="Result"/> в <see cref="IActionResult"/>.
    /// </summary>
    /// <param name="result">The Result object to convert.</param>
    /// <returns>An IActionResult representing the Result object.</returns>
    public static IActionResult ToActionResult(this Result result) =>
        result.IsSuccess
            ? new OkObjectResult(ApiResponse.Ok(result.SuccessMessage))
            : result.ToHttpNonSuccessResult();

    /// <summary>
    /// Преобразовывает <see cref="Result{T}"/> в <see cref="IActionResult"/>.
    /// </summary>
    /// <typeparam name="T">Тип результирующего значения.</typeparam>
    /// <param name="result">Результат конвертации.</param>
    /// <returns>An <see cref="IActionResult"/> представление результата WebAPI-приложения.</returns>
    public static IActionResult ToActionResult<T>(this Result<T> result) =>
        result.IsSuccess
            ? new OkObjectResult(ApiResponse<T>.Ok(result.Value, result.SuccessMessage))
            : result.ToHttpNonSuccessResult();

    private static IActionResult ToHttpNonSuccessResult(this IResult result)
    {
        var errors = result.Errors.Select(error => new ApiErrorResponse(error)).ToList();

        switch (result.Status)
        {
            case ResultStatus.Invalid:

                var validationErrors = result
                    .ValidationErrors
                    .Select(validation => new ApiErrorResponse(validation.ErrorMessage));

                return new BadRequestObjectResult(ApiResponse.BadRequest(validationErrors));

            case ResultStatus.NotFound:
                return new NotFoundObjectResult(ApiResponse.NotFound(errors));

            case ResultStatus.Forbidden:
                return new ForbidResult();

            case ResultStatus.Unauthorized:
                return new UnauthorizedObjectResult(ApiResponse.Unauthorized(errors));

            default:
                return new BadRequestObjectResult(ApiResponse.BadRequest(errors));
        }
    }
}