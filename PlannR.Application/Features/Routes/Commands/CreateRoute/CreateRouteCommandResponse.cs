using PlannR.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommandResponse : BaseResponse
    {
        public CreateRouteCommandResponse() : base()
        {

        }
        public Guid RouteId { get; set; }
    }
}
