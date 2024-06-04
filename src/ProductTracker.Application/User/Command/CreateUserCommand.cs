using System.ComponentModel.DataAnnotations;
using Ardalis.Result;
using MediatR;
using ProductTracker.Application.User.Response;

namespace ProductTracker.Application.User.Command;

public sealed class CreateCustomerCommand : IRequest<Result<CreatedUserResponse>>
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
}