using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Transports.Bookings.Commands.CreateTransportBooking;
using PlannR.Application.Features.Transports.Bookings.Commands.DeleteTransportBooking;
using PlannR.Application.Features.Transports.Bookings.Commands.UpdateTransportBooking;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingDetail;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingList;
using PlannR.Application.Features.Transports.Bookings.Queries.GetTransportBookingListByTripId;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Authorize]
    [Route("api/Transport/Bookings")]
    [ApiController]
    public class TransportBookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTransportBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TransportBookingListViewModel>>> GetAllTransportBookings()
        {
            var result = await _mediator.Send(new GetTransportBookingListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetTransportBookingById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TransportBookingDetailViewModel>> GetTransportBookingById(Guid id)
        {
            var query = new GetTransportBookingDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("trip/{tripId}", Name = "GetAllTransportBookingsByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TransportBookingListByTripIdViewModel>>> GetAllTransportBookingsByTripId(Guid tripId)
        {
            var query = new GetTransportBookingListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddTransportBooking")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTransportBookingCommand createTransportBookingCommand)
        {
            var id = await _mediator.Send(createTransportBookingCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateTransportBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTransportBookingCommand updateTransportBookingCommand)
        {
            await _mediator.Send(updateTransportBookingCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTransportBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteTransportBookingCommand = new DeleteTransportBookingCommand() { BookingId = id };
            await _mediator.Send(deleteTransportBookingCommand);
            return NoContent();
        }
    }
}
