using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Events.Types.Commands.CreateEventType;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeByName;
using PlannR.Application.Features.Events.Types.Queries.GetEventTypeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<ActionResult<ICollection<EventTypeListViewModel>>> GetAllEventTypes()
        {
            var result = await _mediator.Send(new GetEventTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{name}",Name = "GetEventTypeByName")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventTypeByNameViewModel>> GetEventTypeByName(string name)
        {
            var query = new GetEventTypeByNameQuery() { Name = name };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddEventType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventTypeCommand createEventTypeCommand)
        {
            var id = await _mediator.Send(createEventTypeCommand);
            return Ok(id);
        }
    }
}