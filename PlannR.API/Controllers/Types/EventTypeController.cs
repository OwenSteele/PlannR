using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Events.Types.Commands.CreateEventType;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/Event/Types")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEventTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<EventTypeListDataModel>>> GetAllEventTypes()
        {
            var result = await _mediator.Send(new GetEventTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{name}", Name = "GetEventTypeByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventTypeByNameDataModel>> GetEventTypeByName(string name)
        {
            var query = new GetEventTypeByNameQuery() { Name = name };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(Name = "AddEventType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventTypeCommand createEventTypeCommand)
        {
            var id = await _mediator.Send(createEventTypeCommand);
            return Ok(id);
        }
    }
}