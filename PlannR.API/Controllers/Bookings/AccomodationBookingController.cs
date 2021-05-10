using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Accomodations.Bookings.Commands.CreateAccomodationBooking;
using PlannR.Application.Features.Accomodations.Bookings.Commands.DeleteAccomodationBooking;
using PlannR.Application.Features.Accomodations.Bookings.Commands.UpdateAccomodationBooking;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingDetail;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingList;
using PlannR.Application.Features.Accomodations.Bookings.Queries.GetAccomodationBookingListByTripId;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Authorize]
    [Route("api/Accomodation/Bookings")]
    [ApiController]
    public class AccomodationBookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccomodationBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAccomodationBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<AccomodationBookingListDataModel>>> GetAllAccomodationBookings()
        {
            var result = await _mediator.Send(new GetAccomodationBookingListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAccomodationBookingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccomodationBookingDetailDataModel>> GetAccomodationBookingById(Guid id)
        {
            var query = new GetAccomodationBookingDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("trip/{tripId}", Name = "GetAllAccomodationBookingsByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<AccomodationBookingListByTripIdDataModel>>> GetAllAccomodationBookingsByTripId(Guid tripId)
        {
            var query = new GetAccomodationBookingListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddAccomodationBooking")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccomodationBookingCommand createAccomodationBookingCommand)
        {
            var id = await _mediator.Send(createAccomodationBookingCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateAccomodationBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAccomodationBookingCommand updateAccomodationBookingCommand)
        {
            await _mediator.Send(updateAccomodationBookingCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAccomodationBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAccomodationBookingCommand = new DeleteAccomodationBookingCommand() { BookingId = id };
            await _mediator.Send(deleteAccomodationBookingCommand);
            return NoContent();
        }
    }
}
