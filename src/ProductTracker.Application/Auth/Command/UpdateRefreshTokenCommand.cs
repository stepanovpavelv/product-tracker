using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Auth.Response;

namespace ProductTracker.Application.Auth.Command;

/// <summary>
/// Команда на обновление refresh-токена 
/// </summary>
public sealed class UpdateRefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>
{
    /// <summary>
    /// Токен для обновления идентификационных данных.
    /// </summary>
    [Required]
    [DataType(DataType.Text)]
    public required string RefreshToken { get; set; }
}