using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.ViewModels.Trips
{
    public class EditTripViewModel
    {
        [Required]
        public Guid TripId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Trip name needs to be between 2 and 30 characters long")]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Trip description can't be too long! 100 characters max.")]
        public string Description { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        public Guid? StartLocationId { get; set; }
        public Guid? EndLocationId { get; set; }
    }
}
