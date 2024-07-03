using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using ProductTracker.Web.Extensions;
using ProductTracker.Web.Model;

namespace ProductTracker.Web.Controllers.v1;

[ApiController]
[ApiVersion( 1.0 )]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <response code="200">Возвращает идентификатор зарегистрированного пользователя.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<RegisteredUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody][Required] RegisterUserCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}