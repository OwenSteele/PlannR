using PlannR.App.Infrastructure.ViewModels.Nested;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Accomodation
{
    public class EditAccomodationViewModel
    {
        public Guid AccomodationId { get; set; }
        [Required]
        public Guid TripId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid AccomodationTypeId { get; set; }
        public decimal? CostPerNight { get; set; }
        public int Rooms { get; set; }
        public int Nights { get; set; }
        public Guid? BookingId { get; set; }
        public string Description { get; set; }
        public Guid? LocationId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get => StartDateTime.AddDays(Rooms); }
    }
}
