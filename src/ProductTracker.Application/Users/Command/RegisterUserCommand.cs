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
    [Required]
    [MaxLength(75)]
    [DataType(DataType.Text)]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(75)]
    [DataType(DataType.Text)]
    public required string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public required DateOnly DateOfBirth { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [MaxLength(50)]
    public required string Login { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [MaxLength(300)]
    public required string Password { get; set; }
}