using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Auth.Response;

namespace ProductTracker.Application.Auth.Command;

/// <summary>
/// Команда на аутентификацию пользователя.
/// </summary>
public sealed class LoginCommand : IRequest<Result<AuthTokenResponse>>
{
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    [Required]
    [DataType(DataType.Text)]
    [MaxLength(50)]
    public required string Login { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    [Required]
    [DataType(DataType.Text)]
    [MaxLength(300)]
    public required string Password { get; set; }
}