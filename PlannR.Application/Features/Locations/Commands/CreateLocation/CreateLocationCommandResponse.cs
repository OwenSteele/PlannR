using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandResponse : BaseResponse
    {
        public CreateLocationCommandResponse(): base()
        {

        }
        public Guid LocationId { get; set; }
    }
}
