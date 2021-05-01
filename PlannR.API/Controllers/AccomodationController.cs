using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Accomodations.Commands.CreateAccomodation;
using PlannR.Application.Features.Accomodations.Commands.DeleteAccomodation;
using PlannR.Application.Features.Accomodations.Commands.UpdateAccomodation;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripId;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListByTripIdWithBookings;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationListOnDate;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsDetail;
using PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccomodationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAccomodations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<AccomodationListViewModel>>> GetAllAccomodations()
        {
            var result = await _mediator.Send(new GetAccomodationListQuery());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetAccomodationById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccomodationDetailViewModel>> GetAccomodationById(Guid id)
        {
            var query = new GetAccomodationDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("trip/{tripId}", Name = "GetAllAccomodationByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<AccomodationListByTripIdViewModel>>> GetAllAccomodationByTripId(Guid tripId)
        {
            var query = new GetAccomodationListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("trip/{tripId}/Bookings", Name = "GetAllAccomodationByTripIdWithBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<AccomodationListByTripIdWithBookingsViewModel>>> GetAllAccomodationByTripIdWithBookings(Guid tripId)
        {
            var query = new GetAccomodationListByTripIdWithBookingsQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date:DateTime}", Name = "GetAllAccomodationOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<AccomodationListOnDateViewModel>>> GetAllAccomodationOnDate(DateTime date)
        {
            var query = new GetAccomodationListOnDateQuery() { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddAccomodation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccomodationCommand createAccomodationCommand)
        {
            var id = await _mediator.Send(createAccomodationCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateAccomodation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAccomodationCommand updateAccomodationCommand)
        {
            await _mediator.Send(updateAccomodationCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAccomodation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAccomodationCommand = new DeleteAccomodationCommand() { AccomodationId = id };
            await _mediator.Send(deleteAccomodationCommand);
            return NoContent();
        }
    }
}
