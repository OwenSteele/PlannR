using MediatR;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
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
        public async Task<ActionResult<ICollection<AccomodationBookingListViewModel>>> GetAllAccomodationBookings()
        {
            var result = await _mediator.Send(new GetAccomodationBookingListQuery());
            return Ok(result);
        }

        [HttpGet("{id}",Name = "GetAccomodationBookingById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccomodationBookingDetailViewModel>> GetAccomodationBookingById(Guid id)
        {
            var query = new GetAccomodationBookingDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{tripId}", Name = "GetAllAccomodationBookingsByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<AccomodationBookingListByTripIdViewModel>>> GetAllAccomodationBookingsByTripId(Guid tripId)
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