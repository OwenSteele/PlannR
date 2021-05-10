using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlannR.API.Controllers
{
    [Route("api/Accomodation/Types")]
    [ApiController]
    public class AccomodationTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccomodationTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAccomodationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<AccomodationTypeListDataModel>>> GetAllAccomodationTypes()
        {
            var result = await _mediator.Send(new GetAccomodationTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{name}", Name = "GetAccomodationTypeByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccomodationTypeByNameDataModel>> GetAccomodationTypeByName(string name)
        {
            var query = new GetAccomodationTypeByNameQuery() { Name = name };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize]
        [HttpPost(Name = "AddAccomodationType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccomodationTypeCommand createAccomodationTypeCommand)
        {
            var id = await _mediator.Send(createAccomodationTypeCommand);
            return Ok(id);
        }
    }
}