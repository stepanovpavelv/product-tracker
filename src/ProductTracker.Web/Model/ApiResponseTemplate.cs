using System.Text.Json.Serialization;

namespace ProductTracker.Web.Model;

public sealed class ApiResponse<T> : ApiResponse
{
    public required T Result { get; init; }

    /// <summary>
    /// Конструктор класса <see cref="ApiResponse{T}"/>
    /// </summary>
    [JsonConstructor]
    public ApiResponse(T result, bool success, string successMessage, int statusCode, IEnumerable<ApiErrorResponse> errors)
        : base(success, successMessage, statusCode, errors)
    {
        Result = result;
    }

    /// <summary>
    /// Конструктор класса <see cref="ApiResponse{T}"/>
    /// </summary>
    public ApiResponse() { }

    public static ApiResponse<T> Ok(T result) =>
        new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result };

    public static ApiResponse<T> Ok(T result, string successMessage) =>
        new() { Success = true, StatusCode = StatusCodes.Status200OK, Result = result, SuccessMessage = successMessage };
}