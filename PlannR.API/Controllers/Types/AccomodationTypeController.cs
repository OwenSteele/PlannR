using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeByName;
using PlannR.Application.Features.Accomodations.Types.Queries.GetAccomodationTypeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<ActionResult<ICollection<AccomodationTypeListViewModel>>> GetAllAccomodationTypes()
        {
            var result = await _mediator.Send(new GetAccomodationTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{name}",Name = "GetAccomodationTypeByName")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AccomodationTypeByNameViewModel>> GetAccomodationTypeByName(string name)
        {
            var query = new GetAccomodationTypeByNameQuery() { Name = name };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost(Name = "AddAccomodationType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAccomodationTypeCommand createAccomodationTypeCommand)
        {
            var id = await _mediator.Send(createAccomodationTypeCommand);
            return Ok(id);
        }
    }
}