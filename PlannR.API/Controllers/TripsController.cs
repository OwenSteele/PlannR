using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Trips.Commands.CreateTrip;
using PlannR.Application.Features.Trips.Commands.DeleteTrip;
using PlannR.Application.Features.Trips.Commands.UpdateTrip;
using PlannR.Application.Features.Trips.Queries.GetTripListBetweenDates;
using PlannR.Application.Features.Trips.Queries.GetTripListOnDate;
using PlannR.Application.Features.Trips.Queries.GetTripNameList;
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
        public async Task<ActionResult<ICollection<TripListDataModel>>> GetAllTrips()
        {
            var result = await _mediator.Send(new GetTripListQuery());
            return Ok(result);
        }
        [HttpGet("names", Name = "GetAllTripNamesOnly")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TripNameListDataModel>>> GetAllTripNames()
        {
            var result = await _mediator.Send(new GetTripNameListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetTripById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TripDetailDataModel>> GetTripById(Guid id)
        {
            var query = new GetTripDetailQuery() { TripId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{start:DateTime},{end:DateTime}", Name = "GetAllTripsBetweenDates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TripListBetweenDatesDataModel>>> GetAllTripsBetweenDates(DateTime start, DateTime end)
        {
            var query = new GetTripListBetweenDatesQuery() { StartDateTime = start, EndDateTime = end };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date:DateTime}", Name = "GetAllTripOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TripListOnDateDataModel>>> GetAllTripOnDate(DateTime date)
        {
            var query = new GetTripListOnDateQuery() { DateTime = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddTrip")]
        public async Task<ActionResult<CreateTripCommandResponse>> Create([FromBody] CreateTripCommand createTripCommand)
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
            var deleteTripCommand = new DeleteTripCommand() { TripId = id };
            await _mediator.Send(deleteTripCommand);
            return NoContent();
        }
    }
}
