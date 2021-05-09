using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Events.Commands.CreateEvent;
using PlannR.Application.Features.Events.Commands.DeleteEvent;
using PlannR.Application.Features.Events.Commands.UpdateEvent;
using PlannR.Application.Features.Events.Queries.GetEventListByTripId;
using PlannR.Application.Features.Events.Queries.GetEventListByTripIdWithBookings;
using PlannR.Application.Features.Events.Queries.GetEventListOnDate;
using PlannR.Application.Features.Events.Queries.GetEventsDetail;
using PlannR.Application.Features.Events.Queries.GetEventsList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<EventListDataModel>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventListQuery());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetEventById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDetailDataModel>> GetEventById(Guid id)
        {
            var query = new GetEventDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("trip/{tripId}", Name = "GetAllEventsByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<EventListByTripIdDataModel>>> GetAllEventsByTripId(Guid tripId)
        {
            var query = new GetEventListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("trip/{tripId}/Bookings", Name = "GetAllEventsByTripIdWithBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<EventListByTripIdWithBookingsDataModel>>> GetAllEventsByTripIdWithBookings(Guid tripId)
        {
            var query = new GetEventListByTripIdWithBookingsQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date:DateTime}", Name = "GetAllEventsOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<EventListOnDateDataModel>>> GetAllEventsOnDate(DateTime date)
        {
            var query = new GetEventListOnDateQuery() { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
