using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Transports.Types.Commands.CreateTransportType;
using PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeByName;
using PlannR.Application.Features.Transports.Types.Queries.GetTransportTypeList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/Transport/Types")]
    [ApiController]
    public class TransportTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTransportTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TransportTypeListViewModel>>> GetAllTransportTypes()
        {
            var result = await _mediator.Send(new GetTransportTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{name}", Name = "GetTransportTypeByName")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TransportTypeByNameViewModel>> GetTransportTypeByName(string name)
        {
            var query = new GetTransportTypeByNameQuery() { Name = name };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(Name = "AddTransportType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTransportTypeCommand createTransportTypeCommand)
        {
            var id = await _mediator.Send(createTransportTypeCommand);
            return Ok(id);
        }
    }
}