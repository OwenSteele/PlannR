using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Types.Commands.CreateAccomodationType
{
    public class CreateAccomodationTypeCommandResponse : BaseResponse
    {
        public CreateAccomodationTypeCommandResponse() : base()
        {

        }
        public Guid AccomodationTypeId { get; set; }
    }
}
