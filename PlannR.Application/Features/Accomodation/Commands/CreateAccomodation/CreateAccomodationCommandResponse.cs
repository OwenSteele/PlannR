using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Accomodations.Commands.CreateAccomodation
{
    public class CreateAccomodationCommandResponse : BaseResponse
    {
        public CreateAccomodationCommandResponse() : base()
        {

        }
        public Guid AccomodationId { get; set; }
    }
}
