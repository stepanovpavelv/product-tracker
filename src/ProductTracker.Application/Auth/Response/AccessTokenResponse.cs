using ProductTracker.Application.Common;
using System.Text.Json.Serialization;

namespace ProductTracker.Application.Auth.Response;

/// <summary>
/// Ответ системы на получение токена пользователя.
/// </summary>
public sealed class AccessTokenResponse : IResponse
{
    /// <summary>
    /// Аутентификационный токен.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    /// <summary>
    /// Время жизни токена.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    /// <summary>
    /// Тип токена.
    /// </summary>
    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; }
}