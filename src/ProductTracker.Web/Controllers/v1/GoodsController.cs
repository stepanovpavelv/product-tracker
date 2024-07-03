using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductTracker.Web.Controllers.v1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GoodsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
    }
}