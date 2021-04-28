using PlannR.Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Domain.Shared
{
    public class Booking : AuditableEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public ICollection<FileStream> Reservations { get; set; }
        public decimal Cost { get; set; }
    }
}
