using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Routes.Commands.CreateRoute;
using PlannR.Application.Features.Routes.Commands.DeleteRoute;
using PlannR.Application.Features.Routes.Commands.UpdateRoute;
using PlannR.Application.Features.Routes.Queries.GetRouteDetail;
using PlannR.Application.Features.Routes.Queries.GetRouteListOnDate;
using PlannR.Application.Features.Routes.Queries.GetRoutesList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoutesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllRoutes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<RouteListDataModel>>> GetAllRoutes()
        {
            var result = await _mediator.Send(new GetRouteListQuery());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetRouteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RouteDetailDataModel>> GetRouteById(Guid id)
        {
            var query = new GetRouteDetailQuery() { RouteId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date:DateTime}", Name = "GetAllRouteOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<RouteListOnDateDataModel>>> GetAllRouteOnDate(DateTime date)
        {
            var query = new GetRouteListOnDateQuery() { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddRoute")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRouteCommand createRouteCommand)
        {
            var id = await _mediator.Send(createRouteCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateRoute")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRouteCommand updateRouteCommand)
        {
            await _mediator.Send(updateRouteCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteRoute")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteRouteCommand = new DeleteRouteCommand() { RouteId = id };
            await _mediator.Send(deleteRouteCommand);
            return NoContent();
        }
    }
}
