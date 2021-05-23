using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange;
using PlannR.Application.Features.RoutePoints.Commands.DeleteRoutePointRange;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutePointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutePointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddRoutePointRange")]
        public async Task<ActionResult<CreateRoutePointRangeCommandResponse>> Create([FromBody] ICollection<CreateRoutePointCommand> createRoutePointCommand)
        {
            var createRoutePointRangeCommand = new CreateRoutePointRangeCommand { RoutePointDtos = createRoutePointCommand };
            var id = await _mediator.Send(createRoutePointRangeCommand);
            return Ok(id);
        }

        [HttpDelete(Name = "DeleteRoutePointRange")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete([FromBody] ICollection<Guid> ids)
        {
            var deleteRoutePointCommand = new DeleteRoutePointRangeCommand { RoutePointIds = ids };
            await _mediator.Send(deleteRoutePointCommand);
            return NoContent();
        }
    }
}
