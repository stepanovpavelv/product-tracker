using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Response;
using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Application.Users.Command;

/// <summary>
/// Команда на аутентификацию пользователя.
/// </summary>
public sealed class LoginUserCommand : IRequest<Result<LoginUserResponse>>
{
    [Required]
    [DataType(DataType.Text)]
    [MaxLength(50)]
    public required string Login { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [MaxLength(300)]
    public required string Password { get; set; }
}