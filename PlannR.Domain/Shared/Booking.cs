using PlannR.Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlannR.Domain.Shared
{
    public class Booking : AuditableEntity
    {
        public Guid BookingId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public ICollection<BookingFile> Reservations { get; set; }
        public decimal Cost { get; set; }
    }
}
