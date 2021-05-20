using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Locations.Commands.CreateLocation;
using PlannR.Application.Features.Locations.Commands.DeleteLocation;
using PlannR.Application.Features.Locations.Commands.UpdateLocation;
using PlannR.Application.Features.Locations.Queries.GetLocationsDetail;
using PlannR.Application.Features.Locations.Queries.GetLocationsList;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
     //sample code change
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetAllLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<LocationListDataModel>>> GetAllLocations()
        {
            var result = await _mediator.Send(new GetLocationListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetLocationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LocationDetailDataModel>> GetLocationById(Guid id)
        {
            var query = new GetLocationDetailQuery() { LocationId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddLocation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateLocationCommand createLocationCommand)
        {
            var id = await _mediator.Send(createLocationCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateLocation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateLocationCommand updateLocationCommand)
        {
            await _mediator.Send(updateLocationCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteLocation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteLocationCommand = new DeleteLocationCommand() { LocationId = id };
            await _mediator.Send(deleteLocationCommand);
            return NoContent();
        }
    }
}
