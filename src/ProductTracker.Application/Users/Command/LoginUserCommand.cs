using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Response;

namespace ProductTracker.Application.Users.Command;

/// <summary>
/// Команда на аутентификацию пользователя.
/// </summary>
public sealed class LoginUserCommand : IRequest<Result<AuthTokenUserResponse>>
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