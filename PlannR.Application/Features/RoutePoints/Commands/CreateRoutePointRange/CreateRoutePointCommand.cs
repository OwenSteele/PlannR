using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Application.Features.RoutePoints.Commands.CreateRoutePointRange
{
    public class CreateRoutePointCommand
    {
        public Guid RouteId { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? EventId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
