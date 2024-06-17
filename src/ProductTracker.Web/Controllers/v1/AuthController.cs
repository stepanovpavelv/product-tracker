using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using MediatR;
using ProductTracker.Application.Auth.Command;
using ProductTracker.Application.Auth.Response;
using ProductTracker.Web.Extensions;
using ProductTracker.Web.Model;

namespace ProductTracker.Web.Controllers.v1;

// TODO: make urls as oauth-urls
// https://auth0.com/docs/secure/tokens/refresh-tokens/get-refresh-tokens
// сделать один метод, внутри метода контроллера проверять grant_type
// если client_credentials , то access_токен ; если authorization_code , то refresh_токен
// добавить енум грант_тайп и проверить в сваггере.

[ApiController]
[ApiVersion( 1.0 )]
[Route("oauth/token")]
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
    [ProducesResponseType(typeof(ApiResponse<AuthTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromQuery][Required] string grantType, [FromBody][Required] LoginCommand command) =>
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
    [ProducesResponseType(typeof(ApiResponse<AuthTokenResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCredentials([FromBody][Required] UpdateRefreshTokenCommand command) =>
        (await _mediator.Send(command)).ToActionResult();
}