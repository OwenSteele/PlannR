using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.ViewModels.Transport
{
    public class EditTransportViewModel
    {
        public Guid TransportId { get; set; }
        [Required]
        public Guid TripId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid TransportTypeId { get; set; }
        public Guid? StartLocationId { get; set; }
        public Guid? EndLocationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid? BookingId { get; set; }
        public string Description { get; set; }
    }
}
