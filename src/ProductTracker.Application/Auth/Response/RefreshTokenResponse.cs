using ProductTracker.Application.Common;
using System.Text.Json.Serialization;

namespace ProductTracker.Application.Auth.Response;

/// <summary>
/// Ответ системы на обновление идентификационных данных пользователя.
/// </summary>
public sealed class RefreshTokenResponse : IResponse
{
    /// <summary>
    /// Аутентификационный токен.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    /// <summary>
    /// Токен для обновления данных.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; init; }

    /// <summary>
    /// Тип токена.
    /// </summary>
    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; }
}