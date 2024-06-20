using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using ProductTracker.Application.Auth.Command;
using ProductTracker.Application.Auth.Response;
using ProductTracker.Web.Extensions;
using ProductTracker.Web.Model;

namespace ProductTracker.Web.Controllers.v1;

[ApiController]
[ApiVersion( 1.0 )]
[Route("api/v{version:apiVersion}/oauth/token/")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    
    /// <summary>
    /// Получение необходимых учетных данных пользователя.
    /// </summary>
    /// <response code="200">Возвращает аутентификационные данные.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<AccessTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody][Required] LoginCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
    
    /// <summary>
    /// Получение refresh-токена пользователя.
    /// </summary>
    /// <response code="200">Возвращает аутентификационные данные.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [Authorize]
    [HttpPost("refresh")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshToken([FromBody] GetRefreshTokenCommand command) => 
        (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Обновление токенов доступа пользователя к системе.
    /// </summary>
    /// <response code="200">Возвращает аутентификационные данные.</response>
    /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
    /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
    [HttpPost("refresh/revoke")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<RefreshTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RenewCredentials([FromBody][Required] UpdateRefreshTokenCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}