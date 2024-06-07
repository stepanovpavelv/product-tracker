using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Response;
using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Application.Users.Command;

/// <summary>
/// Команда на обновление refresh-токена 
/// </summary>
public sealed class UpdateUserRefreshTokenCommand : IRequest<Result<AuthTokenUserResponse>>
{
    [Required]
    [DataType(DataType.Text)]
    public required string AccessToken { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public required string RefreshToken { get; set; }
}