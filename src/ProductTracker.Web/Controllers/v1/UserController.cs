using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductTracker.Application.User.Command;
using ProductTracker.Application.User.Response;
using ProductTracker.Web.Model;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace ProductTracker.Web.Controllers.v1
{
    [ApiController]
    [ApiVersion( 1.0 )]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Регистрация нового пользователя.
        /// </summary>
        /// <response code="200">Возвращает идентификатор нового пользователя.</response>
        /// <response code="400">Возвращает перечень валидационных ошибок при некорректном запросе.</response>
        /// <response code="500">Произошла непредвиденная ошибка сервиса.</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<CreatedUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody][Required] CreateUserCommand command) =>
            (await _mediator.Send(command)).ToActionResult();
    }
}