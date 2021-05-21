using PlannR.Application.Features.Accomodations.Dtos.GetAccomodationsList;
using System;

namespace PlannR.Application.Features.Accomodations.Queries.GetAccomodationsList
{
    public class AccomodationListDataModel
    {
        public Guid AccomodationId { get; set; }
        public Guid TripId { get; set; }
        public AccomodationTripDto Trip { get; set; }
        public string Name { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
