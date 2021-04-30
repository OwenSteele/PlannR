using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Trips.Commands.CreateTrip;
using PlannR.Application.Features.Trips.Commands.DeleteTrip;
using PlannR.Application.Features.Trips.Commands.UpdateTrip;
using PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates;
using PlannR.Application.Features.Trips.Queries.GetTripListOnDate;
using PlannR.Application.Features.Trips.Queries.GetTripsDetail;
using PlannR.Application.Features.Trips.Queries.GetTripsList;
using PlannR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTrips")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TripListViewModel>>> GetAllTrips()
        {
            var result = await _mediator.Send(new GetTripListQuery());
            return Ok(result);
        }

        [HttpGet("{id}",Name = "GetTripById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TripListViewModel>>> GetTripById(Guid id)
        {
            var query = new GetTripDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{start},{end}", Name = "GetAllTripsBetweenDates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TripListViewModel>>> GetAllTripsBetweenDates(DateTime start, DateTime end)
        {
            var query = new GetTripListBetweenDatesQuery() { StartDateTime = start, EndDateTime = end };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date}", Name = "GetAllTripOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TripListViewModel>>> GetAllTrips(DateTime date)
        {
            var query = new GetTripListOnDateQuery() { DateTime = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddTrip")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTripCommand createTripCommand)
        {
            var id = await _mediator.Send(createTripCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateTrip")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTripCommand updateTripCommand)
        {
            await _mediator.Send(updateTripCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTrip")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteTripCommand() { TripId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
