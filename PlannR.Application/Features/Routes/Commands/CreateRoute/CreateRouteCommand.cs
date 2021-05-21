using MediatR;
using System;

namespace PlannR.Application.Features.Routes.Commands.CreateRoute
{
    public class CreateRouteCommand : IRequest<Guid>
    {
        public Guid TripId { get; set; }
        public string Name { get; set; }
        public Guid RouteTypeId { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public Guid BookingId { get; set; }
        public string Description { get; set; }
        public Guid LocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
