using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Events.Bookings.Commands.CreateEventBooking;
using PlannR.Application.Features.Events.Bookings.Commands.DeleteEventBooking;
using PlannR.Application.Features.Events.Bookings.Commands.UpdateEventBooking;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingDetail;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingList;
using PlannR.Application.Features.Events.Bookings.Queries.GetEventBookingListByTripId;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Authorize]
    [Route("api/Event/Bookings")]
    [ApiController]
    public class EventBookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEventBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<EventBookingListDataModel>>> GetAllEventBookings()
        {
            var result = await _mediator.Send(new GetEventBookingListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEventBookingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventBookingDetailDataModel>> GetEventBookingById(Guid id)
        {
            var query = new GetEventBookingDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("trip/{tripId}", Name = "GetAllEventBookingsByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<EventBookingListByTripIdDataModel>>> GetAllEventBookingsByTripId(Guid tripId)
        {
            var query = new GetEventBookingListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddEventBooking")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventBookingCommand createEventBookingCommand)
        {
            var id = await _mediator.Send(createEventBookingCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateEventBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventBookingCommand updateEventBookingCommand)
        {
            await _mediator.Send(updateEventBookingCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEventBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventBookingCommand = new DeleteEventBookingCommand() { BookingId = id };
            await _mediator.Send(deleteEventBookingCommand);
            return NoContent();
        }
    }
}
