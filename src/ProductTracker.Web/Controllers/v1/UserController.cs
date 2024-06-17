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

// TODO: make urls as oauth-urls
// https://auth0.com/docs/secure/tokens/refresh-tokens/get-refresh-tokens

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

    /// <summary>
    /// Аутентификация пользователя.
    /// </summary>
    /// <response code="200">Возвращает аутентификационные данные.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<AuthTokenUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody][Required] LoginUserCommand command) =>
        (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Обновление токенов доступа пользователя к системе.
    /// </summary>
    /// <response code="200">Возвращает аутентификационные данные.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<AuthTokenUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCredentials([FromBody][Required] UpdateUserRefreshTokenCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}