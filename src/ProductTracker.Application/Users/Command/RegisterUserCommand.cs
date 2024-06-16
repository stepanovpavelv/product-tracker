using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Response;

namespace ProductTracker.Application.Users.Command;

/// <summary>
/// Команда на создание пользователя.
/// </summary>
public sealed class RegisterUserCommand : IRequest<Result<RegisteredUserResponse>>
{
    /// <summary>
    /// Имя.
    /// </summary>
    [Required]
    [MaxLength(75)]
    [DataType(DataType.Text)]
    public required string FirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    [Required]
    [MaxLength(75)]
    [DataType(DataType.Text)]
    public required string LastName { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public required DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// Логин.
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