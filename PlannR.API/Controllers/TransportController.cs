using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Transports.Commands.CreateTransport;
using PlannR.Application.Features.Transports.Commands.DeleteTransport;
using PlannR.Application.Features.Transports.Commands.UpdateTransport;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripId;
using PlannR.Application.Features.Transports.Queries.GetTransportListByTripIdWithBookings;
using PlannR.Application.Features.Transports.Queries.GetTransportListOnDate;
using PlannR.Application.Features.Transports.Queries.GetTransportsDetail;
using PlannR.Application.Features.Transports.Queries.GetTransportsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }  

        [HttpGet(Name = "GetAllTransports")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TransportListViewModel>>> GetAllTransports()
        {
            var result = await _mediator.Send(new GetTransportListQuery());
            return Ok(result);
        }

        [HttpGet("{id}",Name = "GetTransportById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TransportDetailViewModel>> GetTransportById(Guid id)
        {
            var query = new GetTransportDetailQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{tripId}", Name = "GetAllTransportByTripId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TransportListByTripIdViewModel>>> GetAllTransportByTripId(Guid tripId)
        {
            var query = new GetTransportListByTripIdQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{tripId}/Bookings", Name = "GetAllTransportByTripIdWithBookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TransportListByTripIdWithBookingsViewModel>>> GetAllTransportByTripIdWithBookings(Guid tripId)
        {
            var query = new GetTransportListByTripIdWithBookingsQuery() { TripId = tripId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{date}", Name = "GetAllTransportOnDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ICollection<TransportListOnDateViewModel>>> GetAllTransportOnDate(DateTime date)
        {
            var query = new GetTransportListOnDateQuery() { Date = date };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddTransport")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTransportCommand createTransportCommand)
        {
            var id = await _mediator.Send(createTransportCommand);
            return Ok(id);
        }
        [HttpPut(Name = "UpdateTransport")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTransportCommand updateTransportCommand)
        {
            await _mediator.Send(updateTransportCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTransport")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteTransportCommand = new DeleteTransportCommand() { TransportId = id };
            await _mediator.Send(deleteTransportCommand);
            return NoContent();
        }  
    }
}
